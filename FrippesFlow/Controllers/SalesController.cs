using FrippesFlow.Models;
using FrippesFlow.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrippesFlow.Controllers;
[Route("sales")]
public class SalesController : Controller
{
    private readonly SalesService _salesService;
    public SalesController(SalesService salesService)
    {
        _salesService = salesService;
    }

    //Read Result
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var sales = await _salesService.GetSalesEntriesAsync();
        var viewModel = new SalesChartViewModel
        {
            Weeks = JsonConvert.SerializeObject(sales.Select(s => s.Week)),
            AmountsSold = JsonConvert.SerializeObject(sales.Select(s => s.AmountSold)),
            PricePer = JsonConvert.SerializeObject(sales.Select(s => s.PricePer))
        };
        return View(viewModel);    
        }

    [HttpGet("add")]
    public ActionResult AddEntry()
    {
        return View();
    }
    [HttpPost("add")]
    public async Task<ActionResult> AddEntry(SalesEntry entry)
    {
        await _salesService.AddEntryAsync(entry);
        return RedirectToAction("Index");
    }
}