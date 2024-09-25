using Microsoft.EntityFrameworkCore;
using OilChanges.Components;
using OilChanges.Context;
using OilChanges.DTOs.Mappings;
using OilChanges.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(builder.Configuration
                           .GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient();

//No projeto BlazorAppWeb do Net8 precisa adicionar o Servicos dos controladores.
builder.Services.AddControllers();
//Add serviço do UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(VeiculoDTOMappingProfile));
builder.Services.AddAutoMapper(typeof(OleoDTOMappingProfile));
builder.Services.AddAutoMapper(typeof(FiltroDTOMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(OilChanges.Client._Imports).Assembly);

//No projeto BlazorAppWeb do Net8 precisa definir o mapeamento dos controladores para a api 
//receber os requests enviados.
app.MapControllers();

app.Run();
