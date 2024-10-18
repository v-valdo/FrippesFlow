using FrippesFlow.Models;

public interface IResultRepository
{
    Task<List<Result>> GetAllResultsAsync();
    Task<IngredientPer10k> GetIngredientsAsync();
    Task<MonthlyExpense> GetMonthlyAsync();
    Task<ProductionCost> GetProdCostAsync();
    Task AddResultAsync(Result result);
}