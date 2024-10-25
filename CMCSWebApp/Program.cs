
using CMCSWebApp;
using CMCSWebApp.Data;
using CMCSWebApp.Interfaces;
using CMCSWebApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// add the claim services or repository
builder.Services.AddScoped<IClaimFormRepository, ClaimFormRepository>();

// add the race services or repository
builder.Services.AddScoped<IClaimRepository, ClaimRepository>();

// add the claim services or repository
builder.Services.AddScoped<IReviewClaimsRepository, ReviewClaimsRepository>();

// add the claim services or repository
builder.Services.AddScoped<ISubmittedClaimsRepository, SubmittedClaimsRepository>();






















// wire into an app
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// added code
// Check for the "seeddata" command-line argument


// added code
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    // await Seed.SeedUserAndRolesAsync(app);
    Seed.SeedData(app);
}

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
