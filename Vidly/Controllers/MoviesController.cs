using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
             _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieGenreViewModel
            {
                Genre = genres
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieGenreViewModel()
                {
                    Movie = movie,
                    Genre = _context.Genres.ToList()
                };
                return View("New", viewModel);
            }


            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Stock = movie.Stock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.genreId = movie.genreId;
            }
         
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }







        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();


            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(n => n.Genre).FirstOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();

            return View(movies);

        }

        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();


            var viewModel = new MovieGenreViewModel()
            {
                Movie = movie,
                Genre = _context.Genres.ToList()

            };


            return View("New", viewModel);
        }  



        



        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie {Id = 1, Name = "Shrek"},
        //        new Movie {Id = 2, Name = "Wall-e"}
        //    };
        //}




        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1" },
        //        new Customer { Name = "Customer 2" }
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}


    }

}