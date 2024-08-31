namespace BudgetR.Simplified.Core.StateManagement;
public class ClientContext
{
    public ClientContext()
    {

    }

    public bool UserIsActive { get; set; }
    public bool IsLoggedIn { get; set; }
    public string? FirstName { get; set; }
}
