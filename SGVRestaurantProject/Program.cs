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

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Staff", "Customer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DefaultUser>>();

    var roles = new[] { "Admin", "Staff", "Customer" };

    string email = "admin@sgv.com";
    string password = "Admin1234!";

    if(await userManager.FindByEmailAsync(email) == null)
    {
        var user = new DefaultUser();
        user.UserName = email;
        user.Email = email;
        user.FirstName = "Admin";
        user.LastName = "AdminAdmin";
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();
