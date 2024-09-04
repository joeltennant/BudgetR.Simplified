namespace BudgetR.Simplified.Client.Domain.StateManagement;
public class TransactionsByMonth : BaseState
{
    private readonly HttpClient Http;

    public TransactionsByMonth(HttpClient http)
    {
        Http = http;
    }
}
