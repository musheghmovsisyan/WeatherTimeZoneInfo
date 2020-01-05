using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherTimeZoneInfo.Common
{
    public static class CommonMethods
    {
        public static string GetInfo(string ZipCode, IConfiguration  _config)
        {

            string apiUrl = _config.GetSection("ApiUrl").Value;
            string url = $"{apiUrl}/api/ZipCode/{ZipCode}";


            HttpClient http = new HttpClient();
            //http.DefaultRequestHeaders.Add(schemename, header);
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            return data;
        }

    }
}
