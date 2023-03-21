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
        public Daily daily { get; set; }
    }

    public class Current
    {
        public string icon { get; set; }
        public int icon_num { get; set; }
        public string summary { get; set; }
        public float temperature { get; set; }
        public Wind wind { get; set; }
        //public Precipitation precipitation { get; set; }
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
        public double total { get; set; }
        public string type { get; set; }
    }

    public class Daily
    {
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public string day { get; set; }
        public string weather { get; set; }
        public int icon { get; set; }
        public string summary { get; set; }
        public All_Day all_day { get; set; }
        public object morning { get; set; }
        public object afternoon { get; set; }
        public object evening { get; set; }
    }

    public class All_Day
    {
        public string weather { get; set; }
        public int icon { get; set; }
        public float temperature { get; set; }
        public float temperature_min { get; set; }
        public float temperature_max { get; set; }
        public Wind1 wind { get; set; }
        public Cloud_Cover cloud_cover { get; set; }
        public Precipitation1 precipitation { get; set; }
    }

    public class Wind1
    {
        public float speed { get; set; }
        public string dir { get; set; }
        public int angle { get; set; }
    }

    public class Cloud_Cover
    {
        public int total { get; set; }
    }

    public class Precipitation1
    {
        public float total { get; set; }
        public string type { get; set; }
    }


}

