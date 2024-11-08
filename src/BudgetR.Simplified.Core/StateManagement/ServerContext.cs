using BudgetR.Simplified.Core.Enums;

namespace BudgetR.Simplified.Core.StateManagement;
public class ServerContext
{
    public long? UserId { get; set; }

    public string? AuthenticationId { get; set; }

    public bool IsActive { get; set; }

    public UserType? UserType { get; set; }

    public long? HouseholdId { get; set; }

    public string? ProcessName { get; set; }

    public long? BtaId { get; set; }
}
