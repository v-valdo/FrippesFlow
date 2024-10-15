using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.EntityFrameworkCore;

public class SalesService
{
    private readonly FrippesFlowContext _context;
    private readonly ResultService _resultService;
    public SalesService(FrippesFlowContext context, ResultService resultService)
    {
        _context = context;
        _resultService = resultService;
    }
    public async Task<List<SalesEntry>> GetSalesEntriesAsync()
    {
        return await _context.SalesEntries.ToListAsync();
    }
    public async Task AddEntryAsync(SalesEntry entry)
    {
        await _context.AddAsync(entry);
        await _context.SaveChangesAsync();
        await _resultService.AddResultAsync(entry);
    }

}