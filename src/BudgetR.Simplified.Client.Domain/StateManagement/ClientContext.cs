using BudgetR.Simplified.Client.Domain.Models;

namespace BudgetR.Simplified.Client.Domain.StateManagement;
public class ClientContext
{
    public ClientContext()
    {
        MonthYears = new List<MonthYear>();
    }

    private bool _userIsActive;
    private bool _isLoggedIn;
    private string? _firstName;
    private List<MonthYear> _monthYears;

    public bool UserIsActive
    {
        get { return _userIsActive; }
        set
        {
            _userIsActive = value;
            NotifyStateChanged();
        }
    }

    public bool IsLoggedIn
    {
        get { return _isLoggedIn; }
        set
        {
            _isLoggedIn = value;
            NotifyStateChanged();
        }
    }

    public string? FirstName
    {
        get { return _firstName; }
        set
        {
            _firstName = value;
            NotifyStateChanged();
        }
    }

    public List<MonthYear> MonthYears
    {
        get { return _monthYears; }
        set
        {
            _monthYears = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}
