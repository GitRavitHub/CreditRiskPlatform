namespace PortfolioService.Domain.Entities;

public class Portfolio
{
    public Guid Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal TotalValue { get; set; }
    public string Currency { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; } = true;
}