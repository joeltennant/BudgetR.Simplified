namespace BudgetR.Simplified.Client.Domain.Services;
public class TransactionService : ServiceBase
{
    public TransactionService(HttpClient http, ClientContext clientContext)
        : base(http, clientContext)
    {
    }

    public async Task<List<Transaction>> GetTransactions()
    {
        return await Http.GetFromJsonAsync<List<Transaction>>("api/Transactions/getTransactions");
    }
}
