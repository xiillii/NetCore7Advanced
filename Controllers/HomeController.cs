using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore7Advanced.Models;


namespace NetCore7Advanced.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;

    public HomeController(DataContext dbContext)
    {
        _context = dbContext;
    }

    public IActionResult Index([FromQuery]string selectedCity)
    {
        return View();
    }
}