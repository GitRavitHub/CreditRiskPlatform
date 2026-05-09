namespace CreditScoreService.Application.DTOs;

public class CalculateCreditScoreRequest
{
    public Guid CustomerId { get; set; }

    public decimal AnnualIncome { get; set; }

    public decimal ExistingLoanAmount { get; set; }

    public int MissedPayments { get; set; }

    public int ActiveLoans { get; set; }

}