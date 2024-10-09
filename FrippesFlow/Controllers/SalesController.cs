using FrippesFlow.data;
using Microsoft.AspNetCore.Mvc;
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

            ViewBag.Weeks = JsonConvert.SerializeObject(weeks);  // Skicka veckor som JSON
            ViewBag.AmountsSold = JsonConvert.SerializeObject(amountsSold);  // Skicka antal sålda som JSON

            return View(sales);
        }


        //Read Monthly expense

        //Read Production costs

        //Read IngredientPer10k

        //Create sales per week => SalesEntry

    }
}