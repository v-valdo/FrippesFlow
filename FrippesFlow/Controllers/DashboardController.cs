using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrippesFlow.Controllers
{
    [Route("dashboard")]
    public class DashboardController : Controller
    {
        private readonly SalesService _salesService;
        private readonly FrippesFlowContext _context;

        public DashboardController(SalesService salesService, FrippesFlowContext context)
        {
            _salesService = salesService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {

            var sales = await _salesService.GetSalesEntriesAsync();
            var weeks = sales.Select(s => s.Week);
            var amountsSold = sales.Select(s => s.AmountSold);
            var pricePer = sales.Select(s => s.PricePer);

            ViewBag.Weeks = JsonConvert.SerializeObject(weeks);
            ViewBag.AmountsSold = JsonConvert.SerializeObject(amountsSold);
            ViewBag.PricePer = JsonConvert.SerializeObject(pricePer);

            var results = _context.Results.ToList();
            var prodCost = results.Select(r => r.ProductionCost);
            var totIncome = results.Select(r => r.TotalIncome);

            ViewBag.ProdCost = JsonConvert.SerializeObject(prodCost);
            ViewBag.TotIncome = JsonConvert.SerializeObject(totIncome);

            return View();
        }
    }
}
