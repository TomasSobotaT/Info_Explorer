using InfoExplorer.Models.ApiModels;
using Newtonsoft.Json;

namespace InfoExplorer.Models
{
	public class GeolocationModel
	{
        // instance of HttpClient use across this model
        HttpClient client;

        //api key
        private readonly string apiKeyGeolocation = "5NGKVPTOXK&package=WS5";
        public string Latitude { get; private set; } = "Not Found";
        public string Longitude { get; private set; } = "Not Found";

        // object that will be deserialize from json
        public Geolocation geolocationObject;


        public GeolocationModel()
        {
            client = new HttpClient();
            geolocationObject = new Geolocation();
        }


        /// <summary>
        /// get my location, lat. , lon. and City from www.ip2location.com based my IP
        /// </summary>
        /// <returns></returns>
        public async Task GetGeolocationByIP(string IP)
        {
            Uri urlGeo = new Uri($"https://api.ip2location.com/v2/?ip={IP}&key={apiKeyGeolocation}");
            string jsonStringGeolocation = await client.GetStringAsync(urlGeo);
            geolocationObject = JsonConvert.DeserializeObject<Geolocation>(jsonStringGeolocation);

            Latitude = geolocationObject.latitude.ToString().Replace(',', '.');
            Longitude = geolocationObject.longitude.ToString().Replace(',', '.');
        }

    }
}
