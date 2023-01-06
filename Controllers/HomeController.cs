using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore7Advanced.Models;
using NetCore7Advanced.Models.ViewModels;


namespace NetCore7Advanced.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;

    public HomeController(DataContext dbContext)
    {
        _context = dbContext;
    }

    public IActionResult Index([FromQuery] string selectedCity) =>
        View(new PeopleListViewModel
        {
            People = _context.People
                .Include(p => p.Department).Include(p => p.Location),
            Cities = _context.Locations.Select(l => l.City).Distinct(),
            SelectedCity = selectedCity
        });
}