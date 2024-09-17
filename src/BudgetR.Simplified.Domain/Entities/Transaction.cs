using BudgetR.Simplified.Core.Enums;

namespace BudgetR.Simplified.Server.Domain.Entities;

public class Transaction
{
    [Key]
    [Column(Order = 0)]
    public long TransactionId { get; set; }

    [Column(Order = 1)]
    public string? Description { get; set; }

    [Column(Order = 2)]
    public string AccountName { get; set; }

    [Column(Order = 3)]
    public TransactionType? TransactionType { get; set; }

    [Precision(19, 2)]
    [Column(Order = 4)]
    public decimal Amount { get; set; }

    [Column(Order = 5)]
    public DateOnly? TransactionDate { get; set; }

    [Column(Order = 6)]
    [MaxLength(2)]
    public long MonthYearId { get; set; }
    public MonthYear? MonthYear { get; set; }

    [Column(Order = 7)]
    public long? TransactionCategoryId { get; set; }
    public TransactionCategory? TransactionCategory { get; set; }

    [Column(Order = 8)]
    public long? TransactionBatchId { get; set; }
    public TransactionBatch? TransactionBatch { get; set; }

    [Column(Order = 9)]
    public long UserId { get; set; }
    public User? User { get; set; }

    [Column(Order = 10)]
    public bool PreventRecategorizing { get; set; }

    [Column(Order = 11)]
    public long? BudgetMonthId { get; set; }
    public BudgetMonth? BudgetMonth { get; set; }
}
