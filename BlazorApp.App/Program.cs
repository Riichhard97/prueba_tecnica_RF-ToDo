using BlazorApp.App;
using BlazorApp.App.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5046") });

builder.Services.AddSweetAlert2();
builder.Services.AddScoped<IGoalServices, GoalServices>();
builder.Services.AddScoped<IActivityServices, ActivityServices>();

await builder.Build().RunAsync();
