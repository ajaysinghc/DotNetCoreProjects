using Microsoft.AspNetCore.Mvc;

namespace gigstore.Controllers
{
    public class GigsController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}