using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FrippesFlow.ViewModels;

namespace FrippesFlow.Controllers;

[Route("dashboard")]
public class DashboardController : Controller
{

    private readonly IResultRepository _resultRepository;
    
        private readonly SalesService _salesService;

    public DashboardController(IResultRepository resultRepository, SalesService salesService)    

    {
        _resultRepository = resultRepository;
        _salesService = salesService;
    }       
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var results = await _resultRepository.GetAllResultsAsync();
        var sales = await _salesService.GetSalesEntriesAsync();

        var viewModelResult = new ResultChartViewModel
        {
            Week = JsonConvert.SerializeObject(results.Select(s => s.Date)),
            ProdCost = JsonConvert.SerializeObject(results.Select(s => s.ProductionCost)),
            TotIncome = JsonConvert.SerializeObject(results.Select(s => s.TotalIncome))
        };

        var viewModelSales = new SalesChartViewModel
        {
            Weeks = JsonConvert.SerializeObject(sales.Select(s => s.Week)),
            AmountsSold = JsonConvert.SerializeObject(sales.Select(s => s.AmountSold)),
            PricePer = JsonConvert.SerializeObject(sales.Select(s => s.PricePer))
        };

        ViewBag.ResultChart = viewModelResult;
        ViewBag.SalesChart = viewModelSales;
        return View();
    }
}