using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.DataService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IProductService, ProductRepositoryService>();
builder.Services.AddTransient<DataService>();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication("Coockie").
    AddCookie(config =>
{
    config.LoginPath = "/Login/Index";
});


builder.Services.AddAuthorization(configure =>
{
    configure.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});

builder.Services.AddDbContext<ApplicationDbContext>(option
    => option.UseSqlServer("Server=DESKTOP-0VV5V8P; Database=Store; Trusted_Connection=True"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(services =>
    {
        services.User.RequireUniqueEmail = true;
        services.Password.RequireDigit = false;
        services.Password.RequireLowercase = false;
        services.Password.RequireUppercase = false;
        services.Password.RequireNonAlphanumeric = false;
        services.Password.RequiredLength = 5;

    }).AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{controller = Admin}/{ action = Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
