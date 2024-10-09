using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
            var weeks = sales.Select(s => s.Week).ToList();  // Hämta veckor som etiketter
            var amountsSold = sales.Select(s => s.AmountSold).ToList();  // Hämta antal sålda produkter
            var pricePer = sales.Select(s => s.PricePer).ToList();  // Hämta veckor som etiketter


            ViewBag.Weeks = JsonConvert.SerializeObject(weeks);  // Skicka veckor som JSON
            ViewBag.AmountsSold = JsonConvert.SerializeObject(amountsSold);  // Skicka antal sålda som JSON
            ViewBag.PricePer = JsonConvert.SerializeObject(pricePer);  // Skicka antal sålda som JSON


            return View(sales);
        }


        //Read Monthly expense

        //Read Production costs

        //Read IngredientPer10k

        //Create sales per week => SalesEntry
        [HttpGet("add")]
        public ActionResult AddEntry()
        {
            return View();
        }
        [HttpPost("add")]
        public ActionResult AddEntry(SalesEntry entry)
        {
            _context.Add(entry);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}