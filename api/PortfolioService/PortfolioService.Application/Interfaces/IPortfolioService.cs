using PortfolioService.Application.DTOs;
using PortfolioService.Domain.Entities;

namespace PortfolioService.Application.Interfaces;

public interface IPortfolioService
{
//createPortfolio
    Task<Guid> CreatePortfolioAsync(CreatePortfolioRequest request, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Portfolio>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Portfolio?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

//UpdatePortfolio
    Task<bool> UpdatePortfolioAsync(Guid id, UpdatePortfolioRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeletePortfolioAsync(Guid id, CancellationToken cancellationToken = default);
}