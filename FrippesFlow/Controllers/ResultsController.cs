using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace FrippesFlow.Controllers
{
    [Route("results")]
    public class ResultsController : Controller
    {
        private readonly FrippesFlowContext _context;

        public ResultsController(FrippesFlowContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var results = _context.Results.ToList();

            // Förbered data för Chart.js
            var week = results.Select(r => r.Date);
            var prodCost = results.Select(r => r.ProductionCost);
            var totIncome = results.Select(r => r.TotalIncome);

            ViewBag.Weeks = JsonConvert.SerializeObject(week);
            ViewBag.ProdCost = JsonConvert.SerializeObject(prodCost);
            ViewBag.TotIncome = JsonConvert.SerializeObject(totIncome);

            return View(results);
        }

    }
}
