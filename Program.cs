using Microsoft.EntityFrameworkCore;
using NetCore7Advanced.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:PeopleConnection"]);
    options.EnableSensitiveDataLogging(true);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

SeedData.SeedDatabase(app);

app.Run();


