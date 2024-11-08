using BudgetR.Simplified.Core.Enums;

namespace BudgetR.Simplified.Client.Domain.Models;
public class Account
{
    public long AccountId { get; set; }
    public string DisplayName { get; set; }
    public string LongName { get; set; }
    public decimal Balance { get; set; }
    public long AccountTypeId { get; set; }
    public string AccountType { get; set; }
    public BalanceType BalanceType { get; set; }
    public DateTime CreatedAt { get; set; }

    //balance type to string
    public string BalanceTypeString => BalanceType switch
    {
        BalanceType.Debit => "Debit",
        BalanceType.Credit => "Credit",
        _ => "Unknown"
    };
}
