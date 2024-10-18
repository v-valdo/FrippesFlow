using FrippesFlow.data;
using FrippesFlow.Models;
using Microsoft.EntityFrameworkCore;

public class SalesRepository : ISalesRepository
{
    private readonly FrippesFlowContext _context;
    public SalesRepository(FrippesFlowContext context)
    {
        _context = context;
    }
    public async Task AddAsync(SalesEntry entry)
    {
        await _context.AddAsync(entry);
        await _context.SaveChangesAsync();
    }

    public async Task<List<SalesEntry>> GetAllAsync()
    {
        return await _context.SalesEntries.ToListAsync();
    }
}