namespace CreditScoreService.Application.Interfaces;

public interface ICreditScoreService
{
    int CalculateCreditScore(decimal annualIncome);
}