using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore7Advanced.Advanced.Services;
using NetCore7Advanced.Models;
using NetCore7Advanced.Models.ViewModels;


namespace NetCore7Advanced.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    private readonly ToggleService _toggleService;

    public HomeController(DataContext dbContext, ToggleService ts)
    {
        _context = dbContext;
        _toggleService = ts;
    }

    public IActionResult Index([FromQuery] string selectedCity) =>
        View(new PeopleListViewModel
        {
            People = _context.People
                .Include(p => p.Department).Include(p => p.Location),
            Cities = _context.Locations.Select(l => l.City).Distinct(),
            SelectedCity = selectedCity
        });

    public string Toggle() => $"Enabled: {_toggleService.ToggleComponents()}";
}