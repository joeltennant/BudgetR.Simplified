namespace BudgetR.Simplified.Client.Domain.Services;
public class AccountService : ServiceBase
{
    public AccountService(HttpClient http, ClientContext clientContext)
        : base(http, clientContext)
    {
    }

    public async Task GetAccounts()
    {
        var result = await Http.GetFromJsonAsync<List<Account>>("api/Accounts/");
        ClientContext.Accounts.AddAccountList(result);
    }

    public async Task<bool> CreateAccount(string? displayName, string? longName, decimal? Balance, long? AccountTypeId)
    {
        var response = await Http.PostAsJsonAsync("api/Accounts/", new
        {
            DisplayName = displayName,
            LongName = longName,
            Balance,
            AccountTypeId
        });

        if (response.IsSuccessStatusCode)
        {
            long id = await response.Content.ReadFromJsonAsync<long>();
            ClientContext.Accounts.AddAccount(new Account
            {
                AccountId = id,
                DisplayName = displayName,
                LongName = longName,
                Balance = Balance.Value,
                AccountTypeId = AccountTypeId.Value,
                CreatedAt = DateTime.UtcNow
            });
        }

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateAccount(long? AccountId, string newName, string newLongName, decimal? newBalance)
    {
        var response = await Http.PutAsJsonAsync("api/Accounts", new
        {
            AccountId,
            DisplayName = newName,
            LongName = newLongName,
            Balance = newBalance
        });

        if (response.IsSuccessStatusCode)
        {
            ClientContext.Accounts.UpdateAccount(AccountId, newName, newLongName, newBalance);
        }

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAccount(long id)
    {
        var response = await Http.DeleteAsync($"api/Accounts/{id}");

        if (response.IsSuccessStatusCode)
        {
            ClientContext.Accounts.RemoveAccount(id);
        }
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> GetAccountTypes()
    {
        var response = await Http.GetFromJsonAsync<List<AccountType>>("api/Accounts/AccountTypes/");

        if (response != null)
        {
            ClientContext.Accounts.AccountTypes.AddRange(response);
            return true;
        }

        return false;
    }
}
