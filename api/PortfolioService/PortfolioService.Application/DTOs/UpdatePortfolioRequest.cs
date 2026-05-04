namespace PortfolioService.Application.DTOs;

public class UpdatePortfolioRequest
{
    public string CustomerId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
    public string Currency { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}