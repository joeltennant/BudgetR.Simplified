namespace BudgetR.Simplified.Client.Domain.Services;
public class TransactionCategoryService : ServiceBase
{
    public TransactionCategoryService(HttpClient http, ClientContext clientContext)
        : base(http, clientContext)
    {
    }

    public async Task LoadTransactionCategories()
    {
        var results = await Http.GetFromJsonAsync<List<TransactionCategory>>("api/TransactionCategories/getTransactionCategories");
        ClientContext.TransactionCategories.Categories.AddRange(results);
    }

    public async Task<bool> CreateTransactionCategory(string categoryName)
    {
        if (ClientContext.TransactionCategories.Exists(categoryName))
        {
            return false;
        }

        var response = await Http.PostAsJsonAsync("api/TransactionCategories/createTransactionCategory", new { CategoryName = categoryName });

        if (response.IsSuccessStatusCode)
        {
            long id = await response.Content.ReadFromJsonAsync<long>();
            ClientContext.TransactionCategories.Categories.Add(new TransactionCategory
            {
                TransactionCategoryId = id,
                CategoryName = categoryName,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            });
        }

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteTransactionCategory(long id)
    {
        var response = await Http.DeleteAsync($"api/TransactionCategories/{id}");

        if (response.IsSuccessStatusCode)
        {
            var category = ClientContext.TransactionCategories.Categories.FirstOrDefault(c => c.TransactionCategoryId == id);
            if (category != null)
            {
                ClientContext.TransactionCategories.Categories.Remove(category);
            }
        }

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> EditTransactionCategory(long id, string categoryName)
    {
        if (ClientContext.TransactionCategories.Exists(categoryName))
        {
            return false;
        }

        var now = DateTime.Now;
        var response = await Http.PutAsJsonAsync("api/TransactionCategories/renameTransactionCategory", new { CategoryId = id, NewCategoryName = categoryName });

        if (response.IsSuccessStatusCode)
        {
            var category = ClientContext.TransactionCategories.Categories.FirstOrDefault(c => c.TransactionCategoryId == id);
            if (category != null)
            {
                category.CategoryName = categoryName;
                category.ModifiedAt = now;
            }
        }
        return response.IsSuccessStatusCode;
    }
}
