using Microsoft.EntityFrameworkCore;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;
using PortfolioService.Infrastructure.Data;

namespace PortfolioService.Infrastructure.Repositories;

public class PortfolioRepository : IPortfolioRepository
{
    private readonly PortfolioDbContext _context;

    public PortfolioRepository(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Portfolio portfolio, CancellationToken cancellationToken = default)
    {
        await _context.Portfolios.AddAsync(portfolio, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Portfolio>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Portfolios
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Portfolio?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Portfolios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    public async Task<bool> UpdateAsync(Portfolio portfolio, CancellationToken cancellationToken = default)
    {
    _context.Portfolios.Update(portfolio);
    var result = await _context.SaveChangesAsync(cancellationToken);

    return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
    var portfolio = await _context.Portfolios
        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    if (portfolio is null)
        return false;

    _context.Portfolios.Remove(portfolio);
    var result = await _context.SaveChangesAsync(cancellationToken);

    return result > 0;
    }

    
}