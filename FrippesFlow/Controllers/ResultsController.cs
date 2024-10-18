using FrippesFlow.data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FrippesFlow.ViewModels;


namespace FrippesFlow.Controllers;
[Route("results")]
public class ResultsController : Controller
{
    private readonly IResultRepository _resultRepository;

    public ResultsController(IResultRepository resultRepository)
    {
        _resultRepository = resultRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var results = await _resultRepository.GetAllResultsAsync();

        var viewModel = new ResultChartViewModel
        {
            Week = JsonConvert.SerializeObject(results.Select(s => s.Date)),
            ProdCost = JsonConvert.SerializeObject(results.Select(s => s.ProductionCost)),
            TotIncome = JsonConvert.SerializeObject(results.Select(s => s.TotalIncome))
        };

        return View(viewModel);
    }
}