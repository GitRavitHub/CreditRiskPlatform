namespace PortfolioService.Application.DTOs;

public class CreatePortfolioRequest
{
    public string CustomerId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal InitialValue { get; set; }
    public string Currency { get; set; } = string.Empty;
}