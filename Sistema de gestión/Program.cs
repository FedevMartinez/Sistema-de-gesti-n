using Microsoft.EntityFrameworkCore;
using Models.Context;
using Repositories.Interface;
using Repositories.Repository;
using Services;
using Sistema_de_gestión.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SistemaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Base")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IProductRepository, ProductoRepository>();

builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<AutoMapping>();
builder.Services.AddScoped<AutoMapper.Mapper>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
