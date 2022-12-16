using BethanyPieShop.Models;

using Microsoft.EntityFrameworkCore;

//custom scope to di container
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();


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
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();//home is the controller if not it will use action
DbInitializer.Seed(app);
app.Run();
