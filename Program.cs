using DatabaseWrapper.Core;
using Datos.Models;
using maquinas.Models;
using System;
using Watson.ORM.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

DatabaseSettings settings = new DatabaseSettings("./maquina.db");
WatsonORM orm = new WatsonORM(settings);
orm.InitializeDatabase();
orm.InitializeTable(typeof(DatosMaquinas));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
