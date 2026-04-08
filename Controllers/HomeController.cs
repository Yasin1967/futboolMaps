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

    public async Task<IActionResult> Index()
    {
        var cities = await _context.Cities.ToListAsync();
        return View(cities);
    }

    [HttpGet]
    // 4. Hafta: Şehir detaylarını AJAX ile getiren servis yapısı kuruldu.
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

    // 5. Hafta: Şehir detaylarını ayrı bir sayfada gösteren view yapısı eklendi.
    public async Task<IActionResult> CityDetails(int id)
    {
        var city = await _context.Cities
            .Include(c => c.Teams)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (city == null)
            return NotFound();

        return View(city);
    }

    public async Task<IActionResult> TeamDetails(int id)
    {
        var team = await _context.Teams
            .Include(t => t.City)
            .Include(t => t.League)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (team == null)
            return NotFound();

        return View(team);
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
