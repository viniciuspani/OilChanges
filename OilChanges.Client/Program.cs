using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OilChanges.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IOleoService, OleoService>();
builder.Services.AddScoped<IFiltroService, FiltroService>();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
