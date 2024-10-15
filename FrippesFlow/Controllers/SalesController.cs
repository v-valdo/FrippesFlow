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
        private readonly SalesService _salesService;
        public SalesController(SalesService salesService)
        {
            _salesService = salesService;
        }

        //Read Result
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var sales = await _salesService.GetSalesEntriesAsync();

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
            await _salesService.AddEntryAsync(entry);
            return RedirectToAction("Index");
        }
    }
}