namespace BudgetR.Simplified.Server.Transactions.File;
public class TransactionCSVData
{
    public string Status { get; set; }
    public DateOnly? Date { get; set; }
    public string OriginalDescription { get; set; }
    public string SplitType { get; set; }
    public string Category { get; set; }
    public string Currency { get; set; }
    public decimal Amount { get; set; }
    public string UserDescription { get; set; }
    public string Memo { get; set; }
    public string Classification { get; set; }
    public string AccountName { get; set; }
    public string SimpleDescription { get; set; }

}
