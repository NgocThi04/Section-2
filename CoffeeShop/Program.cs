using CoffeeShop;
using CoffeeShop.Models.Interfaces;
using CoffeeShop.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IShoppingCartRepository>(sp => ShoppingCartRepository.GetCart(sp));
builder.Services.AddDbContext<CoffeeShopDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDbContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<CoffeeShopDbContext>();


builder.Services.AddDistributedMemoryCache();   
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();


app.UseRouting();
app.UseAuthentication();


app.UseSession();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
