namespace BudgetR.Simplified.Client.Domain.StateManagement;
public abstract class BaseState
{
    public event Action? OnChange;
    protected void NotifyStateChanged() => OnChange?.Invoke();
}
