using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.EntityFrameworkCore;

public class ResultRepository : IResultRepository
{
    private readonly FrippesFlowContext _context;
    public ResultRepository(FrippesFlowContext context)
    {
        _context = context;
    }
    public async Task<List<Result>> GetAllResultsAsync()
    {
        return await _context.Results.ToListAsync();
    }
    public async Task AddResultAsync(Result result)
    {
        await _context.Results.AddAsync(result);
        await _context.SaveChangesAsync();
    }

    public async Task<IngredientPer10k> GetIngredientsAsync()
    {
        return await _context.IngredientsPer10k.FirstOrDefaultAsync();
    }

    public async Task<MonthlyExpense> GetMonthlyAsync()
    {
        return await _context.MonthlyExpenses.FirstOrDefaultAsync();
    }

    public async Task<ProductionCost> GetProdCostAsync()
    {
        return await _context.ProductionCosts.FirstOrDefaultAsync();
    }
}