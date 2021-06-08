using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class NewsViewModel
    {
        public int id { get; set; }
        public string author { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }
        public string publishedAt { get; set; }
        public string content { get; set; }
        public Dictionary<string, string> current_weather { get; set; }
        public string temperature { get; set; }
        public List<string> weather_descriptions { get; set; }
        public string wind_speed { get; set; }
        public string wind_degree { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
        public string visibility { get; set; }
    }

    public class CityViewModel
    {
        public string city { get; set; }
        public string info { get; set; }
    }

}
