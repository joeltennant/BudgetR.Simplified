namespace BudgetR.Simplified.Client.Domain.Services;
public class MonthYearService : ServiceBase
{
    public MonthYearService(HttpClient http, ClientContext clientContext)
        : base(http, clientContext)
    {
    }
    public async Task LoadInitialMonthYears()
    {
        ClientContext.MonthYear.Months = await Http.GetFromJsonAsync<List<MonthYear>>("api/MonthYears/retrieveMonths");
        ClientContext.MonthYear.SetCurrentMonthYear();
    }
}
