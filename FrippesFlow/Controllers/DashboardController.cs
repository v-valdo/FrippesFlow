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
        
            
            [HttpGet("dashboard")]
            public IActionResult Index()
            {
                return View();

            }
        }
    
}