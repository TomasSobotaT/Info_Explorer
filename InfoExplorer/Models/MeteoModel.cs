using InfoExplorer.Models.ApiModels;
using Newtonsoft.Json;
using System.Net;

namespace InfoExplorer.Models
{
	public class MeteoModel
	{
        // instance of HttpClient use across this model
        HttpClient client;

        //api key
        private readonly string apiKeyWeather = "w7apu0sty7255n5ehmb03lw6xth22sv7opfbswj2";

        // object that will be deserialize from json
        public Meteo meteoObject;

        public MeteoModel()
        {
            client = new HttpClient();
            meteoObject = new Meteo();
        } 



        /// <summary>
        /// get weather information from www.meteosource.com based my longitude and latitude
        /// </summary>
        /// <returns></returns>
        public async Task GetWeather(string Latitude, string Longitude)
        {
            string jsonStringWeather;

            Uri urlWeather = new Uri($"https://www.meteosource.com/api/v1/free/point?lat={Latitude}&lon={Longitude}&sections=current%2Cdaily&language=en&units=auto&key={apiKeyWeather}");

            var response = await client.GetAsync(urlWeather);

            if (response.IsSuccessStatusCode)
            {
                jsonStringWeather = await response.Content.ReadAsStringAsync();
              
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }

            meteoObject = JsonConvert.DeserializeObject<Meteo>(jsonStringWeather);

            int x = 0;

        }


    }
}
