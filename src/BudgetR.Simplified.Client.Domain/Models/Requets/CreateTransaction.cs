using BudgetR.Simplified.Core.Enums;

namespace BudgetR.Simplified.Client.Domain.Models.Requets;
public class CreateTransaction
{
    public string? Description { get; set; }

    public string? AccountName { get; set; }

    public TransactionType? TransactionType { get; set; }

    public decimal Amount { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public string? CategoryName { get; set; }
}
