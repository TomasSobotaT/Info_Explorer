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
            //// get IP ***** for local testing in VS
            //IPModel ipModel = new IPModel();
            //ViewBag.MyIP = await ipModel.GetIP();
            //string ipAddress = ipModel.IP;

            ////get IP ***** for publish
            string ipAddress = HttpContext.Request.Headers["X-Forwarded-For"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            }
            ViewBag.MyIP = ipAddress;




            GeolocationModel geolocationModel = new();
            await geolocationModel.GetGeolocationByIP(ipAddress);
            ViewBag.MyLongitude = geolocationModel.Longitude;
            ViewBag.MyLatitude = geolocationModel.Latitude;
            ViewBag.MyCity = geolocationModel.geolocationObject.city_name;
            ViewBag.MyCountry = geolocationModel.geolocationObject.country_name;
            ViewBag.MyRegion = geolocationModel.geolocationObject.region_name;


            try
            {
                MeteoModel meteoModel = new();
                await meteoModel.GetWeather(geolocationModel.Latitude, geolocationModel.Longitude);
                ViewBag.MyWeatherNow = meteoModel.meteoObject.current.summary;
                ViewBag.MyTemperatureNow = meteoModel.meteoObject.current.temperature;
                ViewBag.MyWeatherIconNow = meteoModel.meteoObject.current.icon_num;

                ViewBag.MyWeatherTomorrow = meteoModel.meteoObject.daily.data[1].summary;
                ViewBag.MyTemperatureTomorrow = meteoModel.meteoObject.daily.data[1].all_day.temperature;
                ViewBag.MyWeatherIconTomorrow = meteoModel.meteoObject.daily.data[1].icon;

            }
            catch (Exception ex)
            {
                string errorMessage = $"Error (Weather forecast): {ex.Message}";
                return BadRequest(errorMessage);
            }


            return View();
        }
    }
}