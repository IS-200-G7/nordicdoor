using Microsoft.AspNetCore.ResponseCompression;
using PDSA_System.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

/**
 * app.Run() kjøres i evig-loop til man avbryter.
 * For å teste tilkobling må du først kjøre prosjektet PDSA_System.Server og avbryte det slik at den fullfører resterende av filen.
 * Husk å bytte passord til ditt eget i appsettings.json filen.
 */

var test = new TestingDbConn();

test.TestConn();




