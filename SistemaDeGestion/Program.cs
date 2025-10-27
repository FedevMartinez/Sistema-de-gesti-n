using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Repositories.Interface;
using Repositories.Repository;
using Services;
using SistemaDeGestion.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SistemaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Base")));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAutoMapper(typeof(AutoMapping));

builder.Services.AddScoped<IProductRepository, ProductoRepository>();

builder.Services.AddHttpClient<ProductoService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<AutoMapping>();
builder.Services.AddScoped<AutoMapper.Mapper>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
