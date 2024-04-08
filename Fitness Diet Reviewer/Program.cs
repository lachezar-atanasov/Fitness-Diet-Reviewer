using Fitness_Diet_Reviewer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

void UpdateAppSetting(string key, string value)
{
    var configJson = File.ReadAllText("appsettings.json");
    var config = JsonSerializer.Deserialize<Dictionary<string, object>>(configJson);
    var test = config[key];
    config[key] = value;
    var updatedConfigJson = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText("appsettings.json", updatedConfigJson);
}
string connectionString = $"Server={System.Environment.MachineName}\\SQLEXPRESS; Database=database5; Trusted_Connection=True; Integrated Security=True; TrustServerCertificate=True;";
var settingsUpdater = new AppSettingsUpdater();
settingsUpdater.UpdateAppSetting("ConnectionStrings:DietAuditorContext", connectionString);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DietReviewerContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Home/Login";
    options.SlidingExpiration = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DietReviewerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DietAuditorContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Seed data on application startup
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<DietReviewerContext>();
    dbContext.Database.Migrate();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Administrator", "Fitness Instructor", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    //var user = await userManager.FindByNameAsync("Lachezar");
    //var result= await userManager.AddToRoleAsync(user, "Fitness instuctor");
    //var user1 = await userManager.FindByNameAsync("Lazar");
    //var result1 = await userManager.AddToRoleAsync(user1, "Fitness instructor");
    //var user2 = await userManager.FindByNameAsync("Pesho");
    //var result2 = await userManager.AddToRoleAsync(user2, "User");
}

app.Run();

