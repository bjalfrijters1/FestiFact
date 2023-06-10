using Festifact.Web;
using Festifact.Web.Services;
using Festifact.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7224") });
builder.Services.AddScoped<IFestivalService, FestivalService>();
builder.Services.AddScoped<IShowService, ShowService>();

await builder.Build().RunAsync();
