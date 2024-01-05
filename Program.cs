using Microsoft.EntityFrameworkCore;
using Opuestos_por_el_Vertice.Data;
using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;
using Opuestos_por_el_Vertice.Services.Account;
using Opuestos_por_el_Vertice.Services.AdminManager;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var service = builder.Services;

// Add services to the container.
service.AddControllersWithViews();
service.AddRouting(config => config.LowercaseUrls = true);

string connectionString = config.GetConnectionString("DefaultConnection");
service.AddDbContext<PostingDbContext>(op =>
    op.UseSqlServer(connectionString));
service.AddLogging(builder => builder.AddConsole());

service.AddTransient<IRepository, DefaultRepository>();
//service.AddTransient<IDataTruck, DataTruck>();            //moving to functional approach
service.AddScoped<UserViewModel>();
//service.AddTransient<ISearcher, DefaultSearcher>();       //moving to functional approach
service.AddTransient<IControllerCore, DefaultControllerCore>();
service.AddTransient<IAdminManager, DefaultAdminManager>();
service.AddTransient<IAccountService, DefaultAccountService>();

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
