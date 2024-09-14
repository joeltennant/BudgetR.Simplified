namespace BudgetR.Simplified.Client.Domain.StateManagement;

public class TransactionCategoriesState : BaseState
{

    public TransactionCategoriesState()
    {
        Categories = new();
    }

    #region --Properties--

    private List<TransactionCategory> _transactionCategories;

    public List<TransactionCategory> Categories
    {
        get { return _transactionCategories; }
        set
        {
            _transactionCategories = value;
            NotifyStateChanged();
        }
    }

    #endregion

    #region --Get--


    #endregion


    #region --Set--
    public void Clear()
    {
        Categories.Clear();
    }

    #endregion
}
