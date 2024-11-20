using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TelegramMiniApp;
using TelegramMiniApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Правильный способ установки базового URL
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TelegramService>();

// Настройка базового пути для маршрутизации
var baseAddress = new Uri(builder.HostEnvironment.BaseAddress);
var basePath = baseAddress.PathAndQuery.TrimEnd('/');
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri($"{baseAddress.Scheme}://{baseAddress.Authority}{basePath}/") });

await builder.Build().RunAsync();