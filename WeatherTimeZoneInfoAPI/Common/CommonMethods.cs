using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherTimeZoneInfoAPI.Models;

namespace WeatherTimeZoneInfoAPI.Common
{
    public static class CommonMethods
    {
        public static GoogleTimeZone GetGoogleInfo(string Location, IConfiguration _config)
        {

            long unixTime = ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();

            string GoogleApiUrl = _config.GetSection("GoogleApiUrl").Value;
            string url = $"{GoogleApiUrl}location={Location}&timestamp={unixTime}";


            HttpClient http = new HttpClient();
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            GoogleTimeZone result = JsonConvert.DeserializeObject<GoogleTimeZone>(data);

            return result;
        }
        public static OpenWeatherMap GetOpenWeatherInfo(string ZipCode, IConfiguration _config)
        {
            //Temperature. Unit Default: Kelvin, Metric: Celsius, Imperial: Fahrenheit.

            string Units = _config.GetSection("OpenWeatherUnits").Value;
            string OpenWeatherMapApiUrl = _config.GetSection("OpenWeatherMapApiUrl").Value;
            string url = $"{OpenWeatherMapApiUrl}units={Units}&zip={ZipCode}";


            HttpClient http = new HttpClient();
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            OpenWeatherMap result = JsonConvert.DeserializeObject<OpenWeatherMap>(data);

            return result;
        }





    }
}
