using BethanyPieShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System.Text.Json.Serialization;
//custom scope to di container
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

//resgistering database 
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
   //concat from connection string and bethanys pie shop
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});
// we have addwithviews dont need for api:builder.Services.AddControllers();  
var app = builder.Build();
//app.MapControllers() dont need we have controllers default for api
//looks for static files wwwroot
app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllerRoute(
        name:"default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
);//home is the controller if not it will use action
app.MapRazorPages();
DbInitializer.Seed(app);
app.Run();
