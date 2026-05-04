using PortfolioService.Application.DTOs;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;

namespace PortfolioService.Application.Services;

public class PortfolioService : IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;

    public PortfolioService(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }

    public async Task<Guid> CreatePortfolioAsync(
        CreatePortfolioRequest request,
        CancellationToken cancellationToken = default)
    {
        var portfolio = new Portfolio
        {
            Id = Guid.NewGuid(),
            CustomerId = request.CustomerId,
            Name = request.Name,
            TotalValue = request.InitialValue,
            Currency = request.Currency,
            CreatedDate = DateTime.UtcNow,
            IsActive = true
        };

        await _portfolioRepository.AddAsync(portfolio, cancellationToken);
        return portfolio.Id;
    }

    public Task<IReadOnlyList<Portfolio>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _portfolioRepository.GetAllAsync(cancellationToken);
    }

    public Task<Portfolio?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _portfolioRepository.GetByIdAsync(id, cancellationToken);
    }
//updatePortfolio
public async Task<bool> UpdatePortfolioAsync(
    Guid id,
    UpdatePortfolioRequest request,
    CancellationToken cancellationToken = default)
{
    var portfolio = await _portfolioRepository.GetByIdAsync(id, cancellationToken);

    if (portfolio is null)
        return false;

    portfolio.CustomerId = request.CustomerId;
    portfolio.Name = request.Name;
    portfolio.TotalValue = request.TotalValue;
    portfolio.Currency = request.Currency;
    portfolio.IsActive = request.IsActive;

    return await _portfolioRepository.UpdateAsync(portfolio, cancellationToken);
}

public async Task<bool> DeletePortfolioAsync(Guid id, CancellationToken cancellationToken = default)
{
    return await _portfolioRepository.DeleteAsync(id, cancellationToken);
}
}