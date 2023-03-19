namespace InfoExplorer.Models.ApiModels
{

    public class Geolocation
    {
        public string response { get; set; } = "Not found";
        public string country_code { get; set; } = "Not found";
        public string country_name { get; set; } = "Not found";
        public string region_name { get; set; } = "Not found";
        public string city_name { get; set; } = "Not found";
        public float latitude { get; set; } = 0;
        public float longitude { get; set; } = 0;
        public int credits_consumed { get; set; } = 0;


    }
}
