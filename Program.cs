using Microsoft.EntityFrameworkCore;
using NetCore7Advanced.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:PeopleConnection"]);
    options.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute("controllers", "controllers/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.MapRazorPages();

SeedData.SeedDatabase(app);

app.Run();


