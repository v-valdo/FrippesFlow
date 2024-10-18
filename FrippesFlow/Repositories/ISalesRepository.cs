using FrippesFlow.Models;

public interface ISalesRepository
{
    Task<List<SalesEntry>> GetAllAsync();
    Task AddAsync(SalesEntry entry);
}