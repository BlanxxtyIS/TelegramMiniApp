using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TelegramMiniApp;
using TelegramMiniApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Добавьте эту строку для правильной работы базового пути
builder.HostEnvironment.BaseAddress = builder.HostEnvironment.BaseAddress.TrimEnd('/') + "/MarlineIOS/";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TelegramService>();

await builder.Build().RunAsync();