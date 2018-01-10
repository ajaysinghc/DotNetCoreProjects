using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public IndexModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }


        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movie = from m in _context.Movie select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                movie = movie.Where(m => m.Title.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(movieGenre))
                movie = movie.Where(m => m.Genre == movieGenre);

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movie.ToListAsync();
        }
    }
}
