namespace BudgetR.Simplified.Client.Domain.StateManagement;
public class MonthYearState : BaseState
{
    public MonthYearState()
    {
        Months = new();
        CurrentMonthYear = new();
    }

    #region --Properties--

    private List<MonthYear> _month;
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

    public List<MonthYear> Months
    {
        get { return _month; }
        set
        {
            _month = value;
            NotifyStateChanged();
        }
    }

    #endregion

    #region --Get--

    #endregion

    #region --SET--

    public void SetCurrentMonthYear()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        CurrentMonthYear = Months.Single(x => x.Year == today.Year && x.Month == today.Month);
    }

    #endregion
}
