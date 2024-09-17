using BudgetR.Simplified.Core.Enums;

namespace BudgetR.Simplified.Server.Domain.Entities;
public class TransactionBatch
{
    [Key]
    public long TransactionBatchId { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public int? RecordCount { get; set; }
    public TransactionSource? Source { get; set; }
    public string? FileName { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}
