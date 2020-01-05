using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherTimeZoneInfoAPI.Models
{
    public class OpenWeatherMap
    {
        public string name { get; set; }



        public TemperatureInfo main { get; set; }

        public GeoCord coord { get; set; }

    }



    public class TemperatureInfo
    {
        public string temp { get; set; }

    }


    public class GeoCord
    {
        public double lon { get; set; }
        public double lat { get; set; }

    }

}
