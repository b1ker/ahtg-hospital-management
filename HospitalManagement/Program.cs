using HospitalManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var connectionString = builder.Configuration.GetConnectionString("HospitalsInventory");
builder.Services.AddDbContext<HospitalsDb>(options =>
    options.UseSqlite(connectionString)
    .EnableSensitiveDataLogging()
);
builder.Services.AddScoped<IHospitalManagementDb, HospitalsDb>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();


await using var scope = app.Services.CreateAsyncScope();
using var db = scope.ServiceProvider.GetService<HospitalsDb>();
await db.Database.MigrateAsync();

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

