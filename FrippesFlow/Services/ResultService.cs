using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.EntityFrameworkCore;

public class ResultService
{
    private readonly IResultRepository _resultRepository;
    private readonly CostCalculation _calc;

    public ResultService(IResultRepository resultRepository, CostCalculation calc)
    {
        _resultRepository = resultRepository;
        _calc = calc;
    }

    public async Task AddResultAsync(SalesEntry entry)
    {
        var ingredients = await _resultRepository.GetIngredientsAsync();
        var monthly = await _resultRepository.GetMonthlyAsync();
        var production = await _resultRepository.GetProdCostAsync();

        decimal totalIngredientCost = _calc.IngredientCost(entry, ingredients, production);
        decimal weeklyExpenses = (decimal)((monthly.Electricity + monthly.Salary) / 4);

        decimal productionCost = totalIngredientCost + weeklyExpenses;

        decimal totalIncome = entry.AmountSold * (decimal)entry.PricePer;

        var result = new Result
        {
            Date = entry.Week,
            ProductionCost = (double)productionCost,
            TotalIncome = (double)totalIncome
        };

        var existingResult = await _resultRepository.GetAllResultsAsync();

        if (existingResult == null)
        {
            await _resultRepository.AddResultAsync(result);
        }
    }
}