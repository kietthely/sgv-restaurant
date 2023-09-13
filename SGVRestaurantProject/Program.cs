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

    string adminEmail = "admin@sgv.com";
    string adminPassword = "Admin1234!";

    if(await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var user = new DefaultUser();
        user.UserName = adminEmail;
        user.Email = adminEmail;
        user.FirstName = "Admin";
        user.LastName = "AdminAdmin";
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, adminPassword);

        await userManager.AddToRoleAsync(user, "Admin");
    }

    string staffEmail = "staff@sgv.com";
    string staffPassword = "Staff1234!";

    if (await userManager.FindByEmailAsync(staffEmail) == null)
    {
        var user = new DefaultUser();
        user.UserName = staffEmail;
        user.Email = staffEmail;
        user.FirstName = "Staff";
        user.LastName = "StaffStaff";
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, staffPassword);

        await userManager.AddToRoleAsync(user, "Staff");
    }

    string testEmail = "test@sgv.com";
    string testPassword = "Test1234!";

    if (await userManager.FindByEmailAsync(testEmail) == null)
    {
        var user = new DefaultUser();
        user.UserName = testEmail;
        user.Email = testEmail;
        user.FirstName = "Test";
        user.LastName = "TestTest";
        user.EmailConfirmed = true;

        await userManager.CreateAsync(user, testPassword);

        await userManager.AddToRoleAsync(user, "Customer");
    }

}

app.Run();
