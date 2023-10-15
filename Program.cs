using Microsoft.EntityFrameworkCore;
using Opuestos_por_el_Vertice.Data;
using Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var service = builder.Services;

// Add services to the container.
service.AddControllersWithViews();

string connectionString = config.GetConnectionString("DefaultConnection");
service.AddDbContext<PostingDbContext>(op =>
    op.UseSqlServer(connectionString));

service.AddTransient<IViewEnvelopment, DefaultViewEnvelopment>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
