using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;
using Microsoft.AspNetCore.Identity;
using SGVRestaurantProject.Models.Users;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SVGRestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SGVRestaurantProject") ??
    throw new InvalidOperationException("Connection string 'SGVRestaurantProject' not found")));

builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SVGRestaurantContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Restaurants}/{action=RestaurantPage}/{id?}");

app.MapRazorPages();

app.Run();
