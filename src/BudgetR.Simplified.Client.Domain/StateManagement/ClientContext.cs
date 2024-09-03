﻿namespace BudgetR.Simplified.Client.Domain.StateManagement;
public class ClientContext
{
    public ClientContext(HttpClient http)
    {
        MonthYear = new MonthYearState(http);
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

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    //STATE
    public MonthYearState MonthYear { get; set; }
}
