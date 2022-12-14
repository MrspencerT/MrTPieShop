using BethanyPieShop.Models;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

//custom scope to di container
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddControllersWithViews();

//resgistering database 
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
   //concat from connection string and bethanys pie shop
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

var app = builder.Build();
//looks for static files wwwroot
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();

app.Run();
