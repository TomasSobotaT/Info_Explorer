using InfoExplorer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace InfoExplorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IPModel ipModel = new IPModel();
            ViewBag.MyIP = await ipModel.GetIP();
      
            GeolocationModel geolocationModel = new GeolocationModel();
            await geolocationModel.GetGeolocationByIP(ipModel.IP);
            ViewBag.MyLongitude = geolocationModel.Longitude;
            ViewBag.MyLatitude = geolocationModel.Latitude;
            ViewBag.MyCity = geolocationModel.geolocationObject.city_name;
            ViewBag.MyCountry = geolocationModel.geolocationObject.country_name;
            ViewBag.MyRegion = geolocationModel.geolocationObject.region_name;

            MeteoModel meteoModel = new MeteoModel();
            await meteoModel.GetWeather(geolocationModel.Latitude,geolocationModel.Longitude);
            ViewBag.MyWeatherNow = meteoModel.meteoObject.current.summary;
            ViewBag.MyTemperatureNow = meteoModel.meteoObject.current.temperature;
            ViewBag.MyWeatherIcon = meteoModel.meteoObject.current.icon_num;
            return View();
        }
    }
}