using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WeatherTimeZoneInfoAPI.Models;

namespace WeatherTimeZoneInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipCodeController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ZipCodeController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        public string Get()
        {
            return "Weather Time Zone Info API is Working";
        }

        [HttpGet("{ZipCode}", Name = "Get")]
        public string Get([FromRoute] string ZipCode)
        {
            string CITY_NAME = "";
            string TEMPERATURE = "";
            string TIMEZONE = "";
            string Message = "";

            string location = "";



            {
                try
                {

                    OpenWeatherMap OpenWeatherInfo = Common.CommonMethods.GetOpenWeatherInfo(ZipCode, _config);






                    if (OpenWeatherInfo != null)
                    {
                        CITY_NAME = OpenWeatherInfo.name;
                        TEMPERATURE = OpenWeatherInfo.main.temp;
                        location = $"{OpenWeatherInfo.coord.lat}, {OpenWeatherInfo.coord.lon}";

                        GoogleTimeZone GoogleInfo = Common.CommonMethods.GetGoogleInfo(location, _config);

                        if (GoogleInfo != null)
                        {
                            TIMEZONE = $"{GoogleInfo.timeZoneId} ({GoogleInfo.timeZoneName})";
                        }
                        else
                        {
                            TIMEZONE = Resources.MessagesRes.Unknown;

                        }

                    }
                    else
                    {
                        CITY_NAME = Resources.MessagesRes.Unknown;
                        TEMPERATURE = Resources.MessagesRes.NotDefined;
                        TIMEZONE = Resources.MessagesRes.Unknown;
                    }


                    Message = $"At the location {CITY_NAME}, \n the temperature is {TEMPERATURE}, \n and the timezone is {TIMEZONE}";
                }
                //catch (Exception ex)
                //{
                //    //Logging
                //    {
                //        CITY_NAME = Resources.MessagesRes.Unknown;
                //        TEMPERATURE = Resources.MessagesRes.NotDefined;
                //        TIMEZONE = Resources.MessagesRes.Unknown;
                //    }


                //    Message = $"At the location {CITY_NAME}, \n the temperature is {TEMPERATURE}, \n and the timezone is {TIMEZONE}";
                //}
                catch
                {
                    //Logging

                    {
                        CITY_NAME = Resources.MessagesRes.Unknown;
                        TEMPERATURE = Resources.MessagesRes.NotDefined;
                        TIMEZONE = Resources.MessagesRes.Unknown;
                    }


                    Message = $"At the location {CITY_NAME}, \n the temperature is {TEMPERATURE}, \n and the timezone is {TIMEZONE}";

                }
            }



            return Message;
        }



    }

}