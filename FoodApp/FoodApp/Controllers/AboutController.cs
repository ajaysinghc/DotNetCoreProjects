using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Controllers
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
