using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7188") });
builder.Services.AddScoped<IClientProvider, ClientsProvider>();
builder.Services.AddScoped<IFurnitureProvider, FurnitureProvider>();
builder.Services.AddScoped<IDriverProvider, DriverProvider>();
builder.Services.AddScoped<IOrderProvider, OrderProvider>();
builder.Services.AddScoped<ICarpenterProvider, CarpenterProvider>();
await builder.Build().RunAsync();


