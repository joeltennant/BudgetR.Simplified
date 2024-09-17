using BudgetR.Simplified.Core.Enums;

namespace BudgetR.Simplified.Server.Domain.Entities.Reference;
public class AccountType
{
    [Key]
    [Column(Order = 0)]
    public long AccountTypeId { get; set; }

    [Column(Order = 1)]
    public string Name { get; set; }

    [Column(Order = 2)]
    public BalanceType BalanceType { get; set; }
}
