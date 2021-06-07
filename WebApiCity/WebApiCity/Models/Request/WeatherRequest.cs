using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCity.Models.Request
{
    public class WeatherRequest
    {
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public string visibility { get; set; }
        public Wind wind { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
    }

    public class Main
    {
        public string temp { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
    }

    public class Wind
    {
        public string speed { get; set; }
        public string deg { get; set; }
    }
}