using System;
using System.Linq;
using gigstore.Data;
using gigstore.Models;
using gigstore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gigstore.Controllers
{
    [Authorize]
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
         private readonly UserManager<ApplicationUser> _userManager;
        public GigsController(ApplicationDbContext dbContext,
                             UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IActionResult Create()
        {
            var viewModel = new GigFormViewModel();
            viewModel.Genres = _dbContext.Genres;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(GigFormViewModel gigModel)
        {
            if(!ModelState.IsValid)
            {
               gigModel.Genres = _dbContext.Genres;
               return View(gigModel);
            }
            var artistId = _userManager.GetUserId(User);
            var gig = new Gig { 
               
               ArtistId = artistId,
               GenreId  = gigModel.Genre,
               Venue  = gigModel.Venue,
               DateTime = DateTime.Parse(string.Format("{0} {1}",gigModel.Date, gigModel.Time))
            };
            _dbContext.Gigs.Add(gig);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}