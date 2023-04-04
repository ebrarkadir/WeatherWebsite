using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WeatherAppProject.Models;
using WeatherAppProject.Services;

namespace WeatherAppProject.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(string city = "Istanbul")
        {
            var weather = await WeatherAPIService.GetWeatherAsync(city);
            if (weather == null)
            {
                return NotFound();
            }
            
            return View(weather);
        }


    }
}