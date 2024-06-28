using CurrieTechnologies.Razor.SweetAlert2;
using Ipgr.Front;
using Ipgr.Front.Repository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//https://localhost:7262/swagger/index.html
//https://localhost:7118/
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7262/") });
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
