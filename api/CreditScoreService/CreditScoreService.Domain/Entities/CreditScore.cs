namespace CreditScoreService.Domain.Entities;

public class CreditScore
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public int Score { get; set; }

    public string RiskLevel { get; set; } = string.Empty;

    public decimal DebtToIncomeRatio { get; set; }

    public decimal PaymentHistoryPercentage { get; set; }

    public DateTime CalculatedAt { get; set; }
}