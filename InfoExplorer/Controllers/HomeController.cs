using InfoExplorer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;

namespace InfoExplorer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly GeolocationModel _geolocationModel;
        private readonly MeteoModel _meteoModel;


        public HomeController(ILogger<HomeController> logger, GeolocationModel geolocationModel, MeteoModel meteoModel)
        {
            _meteoModel = meteoModel;   
            _geolocationModel = geolocationModel;
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
            //if reqest would not work
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            }
            ViewBag.MyIP = ipAddress;


            try
            {
                
                   await _geolocationModel.GetGeolocationByIP(ipAddress);
                ViewBag.MyLongitude = _geolocationModel.Longitude;
                ViewBag.MyLatitude = _geolocationModel.Latitude;
                ViewBag.MyCity = _geolocationModel.geolocationObject.city_name;
                ViewBag.MyCountry = _geolocationModel.geolocationObject.country_name;
                ViewBag.MyRegion = _geolocationModel.geolocationObject.region_name;

               
                await _meteoModel.GetWeather(_geolocationModel.Latitude, _geolocationModel.Longitude);
                ViewBag.MyWeatherNow = _meteoModel.meteoObject.current.summary;
                ViewBag.MyTemperatureNow = _meteoModel.meteoObject.current.temperature;
                ViewBag.MyWeatherIconNow = _meteoModel.meteoObject.current.icon_num;
                ViewBag.MyWeatherTomorrow =_meteoModel.meteoObject.daily.data[1].summary;
                ViewBag.MyTemperatureTomorrow = _meteoModel.meteoObject.daily.data[1].all_day.temperature;
                ViewBag.MyWeatherIconTomorrow = _meteoModel.meteoObject.daily.data[1].icon;
            }

            catch (Exception ex)
            {
                string errorMessage = $"Error: {ex.Message}";
                return BadRequest(errorMessage);
            }


            return View();
        }
    }
}