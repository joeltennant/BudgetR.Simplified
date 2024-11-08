namespace BudgetR.Simplified.Client.Domain.StateManagement;
public class ClientContext : BaseState
{
    public ClientContext()
    {
        MonthYear = new();
        TransactionCategories = new();
        Accounts = new();
    }

    private bool _userIsActive;
    private bool _isLoggedIn;
    private string? _firstName;

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

    //STATE
    public MonthYearState MonthYear { get; set; }
    public TransactionCategoriesState TransactionCategories { get; set; }
    public AccountState Accounts { get; set; }
}
