namespace BudgetR.Simplified.Client.Domain.Models.Requets;
public class CreateTransaction
{
    public CreateTransaction()
    {
        TransactionDate = DateTime.Today;
    }

    public string? Description { get; set; }

    public string? AccountName { get; set; }

    //public TransactionType? TransactionType { get; set; }

    public decimal Amount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? CategoryName { get; set; }
}
