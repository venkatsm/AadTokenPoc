using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Refit;
using System.Diagnostics;
using System.Net.Http.Headers;
using WebApp.Integration.Weather;
using WebApp.Models;
using static System.Formats.Asn1.AsnWriter;

namespace WebApp.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherApi _weatherApi;

        public HomeController(ILogger<HomeController> logger,
            IWeatherApi weatherApi)
        {
            _logger = logger;
            _weatherApi = weatherApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Weather()
        {
            var weatherForecast = await _weatherApi.GetWeatherForecast();

            return View(weatherForecast);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}