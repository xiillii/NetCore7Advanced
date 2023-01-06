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

builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute("controllers", "controllers/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapBlazorHub();

SeedData.SeedDatabase(app);

app.Run();


