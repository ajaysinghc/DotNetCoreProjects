using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApp.Controller
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "1-22-33-33";
        }
        [Route("[Action]")]
        public string Address()
        {
            return "India";
        }
    }
}
