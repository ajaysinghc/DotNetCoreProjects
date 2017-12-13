using System;
using System.Linq;
using gigstore.Data;
using gigstore.Models;
using gigstore.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            viewModel.Title = "Create Gig";
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

        public IActionResult Edit(int id)
        {
             var artistId = _userManager.GetUserId(User);
             Gig gigModel = _dbContext.Gigs.First( x=> x.Id == id);
             if(artistId != gigModel.ArtistId)
                 return NotFound();
             var viewModel = new GigFormViewModel{
                
                Genre  = gigModel.GenreId,
                Venue  = gigModel.Venue,
                Date =  gigModel.DateTime.ToString("MMM dd yyyy"),
                Time =  gigModel.DateTime.ToString("hh:mm")
             };

            viewModel.Genres = _dbContext.Genres;
            viewModel.Title = "Edit Gig";
            return View("Create",viewModel);          

        }
        [HttpPost]
        public IActionResult Edit(GigFormViewModel gigModel)
        {
            if(!ModelState.IsValid)
            {
               gigModel.Genres = _dbContext.Genres;
               return View("Create",gigModel);
            }
            var artistId = _userManager.GetUserId(User);
            
             Gig gig = _dbContext.Gigs.First( x=> x.Id == gigModel.Id);
             if(artistId != gig.ArtistId)
                 return NotFound();

           
               gig.GenreId  = gigModel.Genre;
               gig.Venue  = gigModel.Venue;
               gig.DateTime = DateTime.Parse(string.Format("{0} {1}",gigModel.Date, gigModel.Time));
            
            _dbContext.SaveChanges();
             
            return RedirectToAction("Index","Home");       

        }

        public IActionResult UserGigs()
        {
            var artistId = _userManager.GetUserId(User);
            var gigs = _dbContext.Gigs                                 
            .Include(m=>m.Artist)
            .Include(m=>m.Genre)   
            .Where(m=>m.ArtistId == artistId)            
            .ToList();

            return View("Index",gigs);
        }
    }
}