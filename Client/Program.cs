using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using WhatsAppFarm.Client;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "WhatsAppFarmTheme";
    options.Duration = TimeSpan.FromDays(365);
});
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<WhatsAppFarm.Client.postgresService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddHttpClient("WhatsAppFarm.Server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WhatsAppFarm.Server"));
builder.Services.AddScoped<WhatsAppFarm.Client.SecurityService>();
builder.Services.AddScoped<AuthenticationStateProvider, WhatsAppFarm.Client.ApplicationAuthenticationStateProvider>();
var host = builder.Build();
await host.RunAsync();