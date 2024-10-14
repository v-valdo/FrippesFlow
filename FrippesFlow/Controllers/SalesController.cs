using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace FrippesFlow.Controllers
{

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly FrippesFlowContext _context;
        public SalesController(FrippesFlowContext context)
        {
            _context = context;
        }

        //Read Result
        [HttpGet]
        public ActionResult Index()
        {
            var sales = _context.SalesEntries.ToList();

            // Förbered data för Chart.js
            var weeks = sales.Select(s => s.Week).ToList();
            var amountsSold = sales.Select(s => s.AmountSold).ToList();
            var pricePer = sales.Select(s => s.PricePer).ToList();

            ViewBag.Weeks = JsonConvert.SerializeObject(weeks);
            ViewBag.AmountsSold = JsonConvert.SerializeObject(amountsSold);
            ViewBag.PricePer = JsonConvert.SerializeObject(pricePer);

            return View(sales);
        }

        [HttpGet("add")]
        public ActionResult AddEntry()
        {
            return View();
        }
        [HttpPost("add")]
        public async Task<ActionResult> AddEntry(SalesEntry entry)
        {
            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
            await AddResultForEntry(entry);
            return RedirectToAction("Index");
        }

        // refaktorera till SErvice-mapp?
        private async Task AddResultForEntry(SalesEntry entry)
        {
            var ingredients = await _context.IngredientsPer10k.FirstOrDefaultAsync();
            var monthly = await _context.MonthlyExpenses.FirstOrDefaultAsync();
            var production = await _context.ProductionCosts.FirstOrDefaultAsync();

            var totalMonthly = monthly.Electricity + monthly.Salary;
            double weeklyExpenses = totalMonthly / 4;

            decimal milkCost = entry.AmountSold / 10000m * (decimal)ingredients.Milk * (decimal)production.MilkPerLitre;
            decimal flourCost = entry.AmountSold / 10000m * (decimal)ingredients.Flour * (decimal)production.FlourPerKg;
            decimal yeastCost = entry.AmountSold / 10000m * (decimal)ingredients.Yeast * (decimal)production.YeastPerKg;
            decimal butterCost = entry.AmountSold / 10000m * (decimal)ingredients.Butter * (decimal)production.ButterPerKg;
            decimal saltCost = entry.AmountSold / 10000m * (decimal)ingredients.Salt * (decimal)production.SaltPerKg;
            decimal waterCost = entry.AmountSold / 10000m * (decimal)ingredients.Water * (decimal)production.WaterPerM3;

            decimal totalIngredientCost = milkCost + flourCost + yeastCost + butterCost + saltCost + waterCost;

            decimal personalCostTotal = (decimal)monthly.Salary / 4 * entry.AmountSold;
            decimal electricityCostTotal = (decimal)monthly.Electricity / 4 * entry.AmountSold;

            decimal productionCost = totalIngredientCost + personalCostTotal + electricityCostTotal + (decimal)weeklyExpenses;
            decimal totalIncome = entry.AmountSold * (decimal)entry.PricePer;

            var result = new Result
            {
                Date = entry.Week,
                ProductionCost = (double)productionCost,
                TotalIncome = (double)totalIncome
            };

            var existingResult = await _context.Results
                .FirstOrDefaultAsync(r => r.Date == entry.Week);

            if (existingResult == null)
            {
                _context.Results.Add(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}