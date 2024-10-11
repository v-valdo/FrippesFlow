using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
namespace FrippesFlow.Controllers
{        
    [Route("results")]
    public class ResultsController : Controller
    {
        [HttpGet("results")]
        public IActionResult Index()
        {
            return View();
        }

    }
}