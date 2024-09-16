namespace BudgetR.Simplified.Server.Domain.Entities;
public class TransactionCategory : BaseEntity
{
    [Key]
    [Column(Order = 0)]
    public long TransactionCategoryId { get; set; }

    [Column(Order = 1)]
    public string? CategoryName { get; set; }

    [Column(Order = 2)]
    public long? UserId { get; set; }
    public User? User { get; set; }
}