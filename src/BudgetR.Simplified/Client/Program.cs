using BudgetR.Simplified.Client;
using BudgetR.Simplified.Client.Domain.Services;
using BudgetR.Simplified.Client.Domain.StateManagement;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ServerAPI",
      client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
  .CreateClient("ServerAPI"));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
    options.ProviderOptions.AdditionalProviderParameters.Add("audience", builder.Configuration["Auth0:Audience"]);
});

builder.Services.AddMudServices();

builder.Services.AddSingleton<ClientContext>();
builder.Services.AddScoped<TransactionCategoryService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<MonthYearService>();
builder.Services.AddScoped<AccountService>();

await builder.Build().RunAsync();
