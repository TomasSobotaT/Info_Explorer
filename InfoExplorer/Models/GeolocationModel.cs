using InfoExplorer.Models.ApiModels;
using Newtonsoft.Json;
using System.Net.Http;

namespace InfoExplorer.Models
{
    public class GeolocationModel
    {
        //https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory
        private readonly IHttpClientFactory _httpClientFactory = null!;

        //api key
        private readonly string apiKeyGeolocation = "5NGKVPTOXK&package=WS5";
        public string Latitude { get; private set; } = "Not Found";
        public string Longitude { get; private set; } = "Not Found";

        // object that will be deserialize from json
        public Geolocation geolocationObject;


        public GeolocationModel(IHttpClientFactory httpClientFactory)
        {
                         _httpClientFactory = httpClientFactory;
                          geolocationObject = new Geolocation();
        }


        /// <summary>
        /// get my location, lat. , lon. and City from www.ip2location.com based my IP
        /// </summary>
        public async Task GetGeolocationByIP(string IP)
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            string jsonStringGeolocation;

            Uri urlGeo = new Uri($"https://api.ip2location.com/v2/?ip={IP}&key={apiKeyGeolocation}");

            var response = await client.GetAsync(urlGeo);

            if (response.IsSuccessStatusCode)
            {
                jsonStringGeolocation = await response.Content.ReadAsStringAsync();
                geolocationObject = JsonConvert.DeserializeObject<Geolocation>(jsonStringGeolocation);
                Latitude = geolocationObject.latitude.ToString().Replace(',', '.');
                Longitude = geolocationObject.longitude.ToString().Replace(',', '.');
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }



        }

    }
}
