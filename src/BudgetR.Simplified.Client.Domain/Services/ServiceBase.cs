namespace BudgetR.Simplified.Client.Domain.Services;

public abstract class ServiceBase
{
    protected readonly HttpClient Http;
    protected ClientContext ClientContext;

    public ServiceBase(HttpClient http, ClientContext clientContext)
    {
        Http = http;
        ClientContext = clientContext;
    }
}