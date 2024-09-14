namespace BudgetR.Simplified.Core;
public static class CommonExentions
{
    public static bool IsPopulated<T>(this List<T> list)
    {
        return list != null && list.Count > 0;
    }

    public static bool IsNotPopulated<T>(this List<T> list)
    {
        return !list.IsPopulated();
    }

    public static bool IsNullOrWhiteSpace(this string value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
    public static string RemoveSeconds(this DateTime date)
    {
        return date.ToString("g");
    }
}
