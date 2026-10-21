using ISC_RoleBasedDemo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddSession();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")));
builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using(var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;
        var userManager = services.GetRequiredService<UserManager<Users>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        string[] roles = { "Admin", "User" };
        foreach (var rolename in roles)
        {
            var roleExists = await roleManager.RoleExistsAsync(rolename);
            if(!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole(rolename));
            }
        }

        var adminUsername = "admin123";
        var adminUser = await userManager.FindByNameAsync(adminUsername);
        if(adminUser != null)
        {
            adminUser.UserName = adminUsername;
        }
        if (adminUser == null)
        {
            var User = new Users()
            {
                UserName = adminUsername,
                Email = "admin123@gmail.com",
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(User, "Admin@123");
            if(result.Succeeded)
            {
                await userManager.AddToRoleAsync(User, "Admin");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
