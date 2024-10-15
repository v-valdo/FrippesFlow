using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.AspNetCore.Mvc;
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

            return View(results);
        }

    }
}
