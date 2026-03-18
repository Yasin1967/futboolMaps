using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FOOTBALMAPSV2.Models;
using Microsoft.EntityFrameworkCore;

namespace FOOTBALMAPSV2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly FootballMapsDbContext _context;

    public HomeController(ILogger<HomeController> logger, FootballMapsDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetCityDetails(int id)
    {
        var city = await _context.Cities
            .Include(c => c.Teams)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (city == null)
            return NotFound();

        var result = new
        {
            city.Id,
            city.Name,
            city.History,
            city.Culture,
            city.LocalFood,
            city.NaturalResources,
            Teams = city.Teams.Select(t => new
            {
                t.Id,
                t.Name,
                t.FoundationYear,
                t.LogoUrl
            }).ToList()
        };

        return Json(result);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
