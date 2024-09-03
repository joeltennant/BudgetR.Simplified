using BudgetR.Simplified.Client.Domain.Models;
using System.Net.Http.Json;

namespace BudgetR.Simplified.Client.Domain.StateManagement;
public class MonthYearState : BaseState
{
    private readonly HttpClient Http;

    public MonthYearState(HttpClient http)
    {
        MonthYears = new();
        CurrentMonthYear = new();
        Http = http;
    }

    #region --Properties--

    private List<MonthYear> _monthYears;
    private MonthYear _currentMonthYear;

    public MonthYear CurrentMonthYear
    {
        get { return _currentMonthYear; }
        set
        {
            _currentMonthYear = value;
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

    #endregion

    #region --Get--

    public async Task LoadInitialMonthYears()
    {
        MonthYears = await Http.GetFromJsonAsync<List<MonthYear>>("api/MonthYears/retrieveMonths");
        SetCurrentMonthYear();
    }

    #endregion

    #region --SET--

    public void SetCurrentMonthYear()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        CurrentMonthYear = MonthYears.Single(x => x.Year == today.Year && x.Month == today.Month);
    }

    #endregion
}
