using FrippesFlow.Models;

public class SalesService
{
    private readonly ISalesRepository _salesRepository;
    private readonly ResultService _resultService;
    public SalesService(ISalesRepository salesRepository, ResultService resultService)
    {
        _salesRepository = salesRepository;
        _resultService = resultService;
    }
    public async Task<List<SalesEntry>> GetSalesEntriesAsync()
    {
        return await _salesRepository.GetAllAsync();
    }
    public async Task AddEntryAsync(SalesEntry entry)
    {
        await _salesRepository.AddAsync(entry);
        await _resultService.AddResultAsync(entry);
    }
}