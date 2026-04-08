using FOOTBALMAPSV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FOOTBALMAPSV2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly FootballMapsDbContext _context;

        public AdminController(FootballMapsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stats = new AdminDashboardViewModel
            {
                CityCount = await _context.Cities.CountAsync(),
                TeamCount = await _context.Teams.CountAsync(),
                LeagueCount = await _context.Leagues.CountAsync()
            };
            return View(stats);
        }

        #region City CRUD
        public async Task<IActionResult> Cities()
        {
            var cities = await _context.Cities.Include(c => c.Country).ToListAsync();
            return View(cities);
        }

        public IActionResult CreateCity()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCity(City city)
        {
            ModelState.Remove("Country");
            ModelState.Remove("Teams");

            if (ModelState.IsValid)
            {
                try 
                {
                    // Check if city ID already exists
                    var existingCity = await _context.Cities.FindAsync(city.Id);
                    if (existingCity != null)
                    {
                        ModelState.AddModelError("Id", "Bu plaka koduna sahip bir şehir zaten mevcut.");
                        return View(city);
                    }

                    var coords = CityCoordinateHelper.GetCoordinates(city.Id);
                    city.Latitude = coords.Lat;
                    city.Longitude = coords.Lon;

                    _context.Add(city);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Şehir başarıyla eklendi ve haritaya yerleştirildi.";
                    return RedirectToAction(nameof(Cities));
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Şehir eklenirken bir hata oluştu: " + ex.Message;
                }
            }
            return View(city);
        }

        public async Task<IActionResult> EditCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return NotFound();
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCity(City city)
        {
            ModelState.Remove("Country");
            ModelState.Remove("Teams");

            if (ModelState.IsValid)
            {
                _context.Update(city);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Şehir başarıyla güncellendi.";
                return RedirectToAction(nameof(Cities));
            }
            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city != null)
            {
                _context.Cities.Remove(city);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Cities));
        }
        #endregion

        #region League CRUD
        public async Task<IActionResult> Leagues()
        {
            return View(await _context.Leagues.ToListAsync());
        }

        public IActionResult CreateLeague()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLeague(League league)
        {
            ModelState.Remove("Teams");
            if (ModelState.IsValid)
            {
                _context.Add(league);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Lig başarıyla eklendi.";
                return RedirectToAction(nameof(Leagues));
            }
            return View(league);
        }

        public async Task<IActionResult> EditLeague(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            if (league == null) return NotFound();
            return View(league);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLeague(League league)
        {
            ModelState.Remove("Teams");
            if (ModelState.IsValid)
            {
                _context.Update(league);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Lig başarıyla güncellendi.";
                return RedirectToAction(nameof(Leagues));
            }
            return View(league);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLeague(int id)
        {
            var league = await _context.Leagues.FindAsync(id);
            if (league != null)
            {
                _context.Leagues.Remove(league);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Lig silindi.";
            }
            return RedirectToAction(nameof(Leagues));
        }
        #endregion

        #region Team CRUD
        public async Task<IActionResult> Teams()
        {
            var teams = await _context.Teams.Include(t => t.City).Include(t => t.League).ToListAsync();
            return View(teams);
        }

        public async Task<IActionResult> CreateTeam()
        {
            ViewBag.Cities = await _context.Cities.ToListAsync();
            ViewBag.Leagues = await _context.Leagues.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeam(Team team, IFormFile? logoFile)
        {
            ModelState.Remove("City");
            ModelState.Remove("League");
            ModelState.Remove("LogoUrl");

            if (ModelState.IsValid)
            {
                if (logoFile != null && logoFile.Length > 0)
                {
                    team.LogoUrl = await SaveLogoFile(logoFile);
                }
                else
                {
                    team.LogoUrl = "/images/teams/default-logo.png";
                }

                _context.Add(team);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Takım başarıyla eklendi.";
                return RedirectToAction(nameof(Teams));
            }
            ViewBag.Cities = await _context.Cities.ToListAsync();
            ViewBag.Leagues = await _context.Leagues.ToListAsync();
            return View(team);
        }

        public async Task<IActionResult> EditTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();
            ViewBag.Cities = await _context.Cities.ToListAsync();
            ViewBag.Leagues = await _context.Leagues.ToListAsync();
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeam(Team team, IFormFile? logoFile)
        {
            ModelState.Remove("City");
            ModelState.Remove("League");
            ModelState.Remove("LogoUrl");

            if (ModelState.IsValid)
            {
                if (logoFile != null && logoFile.Length > 0)
                {
                    team.LogoUrl = await SaveLogoFile(logoFile);
                }
                // If no new file, we should keep the old LogoUrl. 
                // However, 'team' comes from the form. If LogoUrl isn't in the form, it will be null.
                // We'll handle this by including a hidden input for LogoUrl in the view.

                _context.Update(team);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Takım başarıyla güncellendi.";
                return RedirectToAction(nameof(Teams));
            }
            ViewBag.Cities = await _context.Cities.ToListAsync();
            ViewBag.Leagues = await _context.Leagues.ToListAsync();
            return View(team);
        }

        private async Task<string> SaveLogoFile(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "teams", fileName);
            
            // Ensure directory exists
            var directory = Path.GetDirectoryName(filePath);
            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return "/images/teams/" + fileName;
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Takım silindi.";
            }
            return RedirectToAction(nameof(Teams));
        }
        #endregion
    }

    public class AdminDashboardViewModel
    {
        public int CityCount { get; set; }
        public int TeamCount { get; set; }
        public int LeagueCount { get; set; }
    }
}
