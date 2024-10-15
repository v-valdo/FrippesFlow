using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.EntityFrameworkCore;

public class ResultService
{
    private readonly FrippesFlowContext _context;

    public ResultService(FrippesFlowContext context)
    {
        _context = context;
    }

    public async Task AddResultAsync(SalesEntry entry)
    {
        var ingredients = await _context.IngredientsPer10k.FirstOrDefaultAsync();
        var monthly = await _context.MonthlyExpenses.FirstOrDefaultAsync();
        var production = await _context.ProductionCosts.FirstOrDefaultAsync();

        var totalMonthly = monthly.Electricity + monthly.Salary;
        double weeklyExpenses = totalMonthly / 4;

        decimal milkCost = entry.AmountSold / 10000m * (decimal)ingredients.Milk * (decimal)production.MilkPerLitre;
        decimal flourCost = entry.AmountSold / 10000m * (decimal)ingredients.Flour * (decimal)production.FlourPerKg;
        decimal yeastCost = entry.AmountSold / 10000m * (decimal)ingredients.Yeast * (decimal)production.YeastPerKg;
        decimal butterCost = entry.AmountSold / 10000m * (decimal)ingredients.Butter * (decimal)production.ButterPerKg;
        decimal saltCost = entry.AmountSold / 10000m * (decimal)ingredients.Salt * (decimal)production.SaltPerKg;
        decimal waterCost = entry.AmountSold / 10000m * (decimal)ingredients.Water * (decimal)production.WaterPerM3;

        decimal totalIngredientCost = milkCost + flourCost + yeastCost + butterCost + saltCost + waterCost;

        decimal personalCostTotal = (decimal)monthly.Salary / 4 * entry.AmountSold;
        decimal electricityCostTotal = (decimal)monthly.Electricity / 4 * entry.AmountSold;

        decimal productionCost = totalIngredientCost + personalCostTotal + electricityCostTotal + (decimal)weeklyExpenses;
        decimal totalIncome = entry.AmountSold * (decimal)entry.PricePer;

        var result = new Result
        {
            Date = entry.Week,
            ProductionCost = (double)productionCost,
            TotalIncome = (double)totalIncome
        };

        var existingResult = await _context.Results
            .FirstOrDefaultAsync(r => r.Date == entry.Week);

        if (existingResult == null)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();
        }
    }
}
