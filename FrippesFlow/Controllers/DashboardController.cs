using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace FrippesFlow.Controllers
{     
    
    [Route("dashboard")]
    public class DashboardController : Controller
    {
                private readonly SalesService _salesService;
        public DashboardController(SalesService salesService)
        {
            _salesService = salesService;

        }
            
            [HttpGet]
        public async Task<ActionResult> Index()
        {
            var sales = await _salesService.GetSalesEntriesAsync();
            // Förbered data för Chart.js
            var weeks = sales.Select(s => s.Week);
            var amountsSold = sales.Select(s => s.AmountSold);
            var pricePer = sales.Select(s => s.PricePer);

            ViewBag.Weeks = JsonConvert.SerializeObject(weeks);
            ViewBag.AmountsSold = JsonConvert.SerializeObject(amountsSold);
            ViewBag.PricePer = JsonConvert.SerializeObject(pricePer);

            return View(sales);
        }

            }
        }
    
