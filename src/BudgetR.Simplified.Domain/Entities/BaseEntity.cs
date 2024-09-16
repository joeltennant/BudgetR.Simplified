namespace BudgetR.Simplified.Server.Domain.Entities;
public class BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public long? BusinessTransactionActivityId { get; set; }
    public BusinessTransactionActivity? BusinessTransactionActivity { get; set; }
}
