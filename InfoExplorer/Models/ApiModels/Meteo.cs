namespace InfoExplorer.Models.ApiModels
{
    public class Meteo
    {

        public string lat { get; set; }
        public string lon { get; set; }
        public int elevation { get; set; }
        public string timezone { get; set; }
        public string units { get; set; }
        public Current current { get; set; }
        public object hourly { get; set; }
        public object daily { get; set; }
    }

    public class Current
    {
        public string icon { get; set; }
        public int icon_num { get; set; }
        public string summary { get; set; }
        public float temperature { get; set; }
        public Wind wind { get; set; }
        public Precipitation precipitation { get; set; }
        public int cloud_cover { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int angle { get; set; }
        public string dir { get; set; }
    }

    public class Precipitation
    {
        public float total { get; set; }
        public string type { get; set; }
    }

}

