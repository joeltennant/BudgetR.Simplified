namespace BudgetR.Simplified.Client.Domain.Models;
public class Transaction
{
    public long TransactionId { get; set; }
    public string? Description { get; set; }

    public string? AccountName { get; set; }

    public string TransactionType { get; set; }

    public int Month { get; set; }
    public int Year { get; set; }

    public decimal Amount { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public string? CategoryName { get; set; }
}
