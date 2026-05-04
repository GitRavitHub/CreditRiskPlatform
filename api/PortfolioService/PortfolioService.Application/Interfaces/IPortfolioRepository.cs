using PortfolioService.Domain.Entities;

namespace PortfolioService.Application.Interfaces;

public interface IPortfolioRepository
{
    Task AddAsync(Portfolio portfolio, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Portfolio>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Portfolio?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Portfolio portfolio, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}