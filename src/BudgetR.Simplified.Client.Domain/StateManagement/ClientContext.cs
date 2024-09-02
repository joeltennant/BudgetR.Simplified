using BudgetR.Simplified.Client.Domain.Models;

namespace BudgetR.Simplified.Client.Domain.StateManagement;
public class ClientContext
{
    public ClientContext()
    {
        MonthYears = new List<MonthYear>();
    }

    public bool UserIsActive { get; set; }
    public bool IsLoggedIn { get; set; }
    public string? FirstName { get; set; }
    public List<MonthYear> MonthYears { get; set; }
}
