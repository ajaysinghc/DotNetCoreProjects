using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gigstore.Models;
using gigstore.Data;
using Microsoft.EntityFrameworkCore;

namespace gigstore.Controllers
{
    public class HomeController : Controller
    {
         private readonly ApplicationDbContext _dbContext;
         public HomeController(ApplicationDbContext dbContext)
         {
             _dbContext = dbContext;
         }
         
        public IActionResult Index()
        {
            var gigs = _dbContext.Gigs
            .Include(m=>m.Artist)
            .Include(m=>m.Genre)
            .ToList();

            return View(gigs);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
