using BlazorComplator.Data;
using BlazorComplator.AppDbContext;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using BlazorComplator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IQueryService, QueryService>();
builder.Services.AddMudServices();
builder.Services.AddDbContext<QueryDbContext>(optinos =>
{
    optinos.UseSqlServer(builder.Configuration.GetConnectionString("QueryDB"));
}); 

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
