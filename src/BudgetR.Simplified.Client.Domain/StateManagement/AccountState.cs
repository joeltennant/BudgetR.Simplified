namespace BudgetR.Simplified.Client.Domain.StateManagement;
public class AccountState : BaseState
{
    public AccountState()
    {
        All = new();
        AccountTypes = new();
    }

    private List<Account> _accounts;
    public List<Account> All//all accounts
    {
        get { return _accounts; }
        set
        {
            _accounts = value;
            NotifyStateChanged();
        }
    }

    private List<AccountType> _accountTypes;
    public List<AccountType> AccountTypes
    {
        get { return _accountTypes; }
        set
        {
            _accountTypes = value;
            NotifyStateChanged();
        }
    }

    public void SetAccounts(List<Account> accounts)
    {
        All = accounts;
    }

    public void AddAccount(Account account)
    {
        All.Add(account);
    }

    public void AddAccountList(List<Account> accounts)
    {
        All.AddRange(accounts);
    }

    public void RemoveAccount(long accountId)
    {
        var account = this.All.FirstOrDefault(c => c.AccountId == accountId);
        if (account != null)
        {
            this.All.Remove(account);
        }
    }

    public void UpdateAccount(long? AccountId, string newName, string newLongName, decimal? newBalance)
    {
        var account = this.All.FirstOrDefault(c => c.AccountId == AccountId);
        if (account != null)
        {
            account.DisplayName = newName;
            account.LongName = newLongName;
            account.Balance = newBalance.Value;
        }
    }

    public void Clear()
    {
        All.Clear();
    }
}
