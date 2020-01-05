using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WeatherTimeZoneInfo.Controllers
{
    public class ZipCodeController : Controller
    {
        private readonly IConfiguration _config;

        public ZipCodeController(IConfiguration config)
        {
            _config = config;
        }


        public IActionResult Info(string ZipCode)
        {



          
            string Message = "";
           
                Message = Common.CommonMethods.GetInfo(ZipCode, _config);

           


            this.ViewData.Add("Message", Message);

            return new PartialViewResult
            {
                ViewName = "_InfoPartial",
                ViewData = this.ViewData
            };
        }
    }
}