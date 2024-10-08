using FrippesFlow.data;
using Microsoft.AspNetCore.Mvc;
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

            return View();
        }

        //Read Monthly expense

        //Read Production costs

        //Read IngredientPer10k

        //Create sales per week => SalesEntry
        

    }
}
