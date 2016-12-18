﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
             //  new Movie { Id = 1, Name = "FP Computers" },
              // new Movie { Id = 2, Name = "Boekhouder" }
            };

            var viewmodel = new MovieViewModel
            {
                Movie = movies
            };


            return View(viewmodel);
        }

    }

}