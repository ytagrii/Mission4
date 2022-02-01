using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // bring in the context file so we can use it.
        private MoviesContext _moviesContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MoviesContext movieDB)
        {
            _logger = logger;
            _moviesContext = movieDB;
            
        }

        //display home page
        public IActionResult Index()
        {
            return View();
        }

        //display podcast page
        public IActionResult Podcasts()
        {
            return View();
        }

        //display all movies
        public IActionResult AllMovies()
        {
            var movies = _moviesContext.responses.Include(x => x.Rating).Include(x => x.Category).ToList();
            return View(movies);
        }

        //get for adding movies 
        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Rating = _moviesContext.ratings.ToList();
            ViewBag.Category = _moviesContext.categories.ToList();
            
            return View();
        }

        //post for adding movies
        [HttpPost]
        public IActionResult AddMovie(Movies mr)
        {
            //make sure the form is valid before submitting
            if (ModelState.IsValid)
            {
                //this is what saves the data to the database
                _moviesContext.Add(mr);
                _moviesContext.SaveChanges();
                return View("Confirmation", mr);
            }
            else
            {
                //return the view if form is not valid
                ViewBag.Rating = _moviesContext.ratings.ToList();
                ViewBag.Category = _moviesContext.categories.ToList();
                return View();
            }
            
        }

        // get edit movie
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _moviesContext.responses.Single(x => x.MovieId == id);
            ViewBag.Rating = _moviesContext.ratings.ToList();
            ViewBag.Category = _moviesContext.categories.ToList();
            return View(movie);

        }

        //Edit movie (actually update here)
        [HttpPost]
        public IActionResult Edit(Movies mr)
        {
            _moviesContext.Update(mr);
            _moviesContext.SaveChanges();
            return RedirectToAction("AllMovies");
        }

        //delete movie (ask)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _moviesContext.responses.Single(x => x.MovieId == id);
            return View(movie);

        }

        //Final Delete movie
        [HttpPost]
        public IActionResult Delete(Movies mr)
        {
            _moviesContext.responses.Remove(mr);
            _moviesContext.SaveChanges();
            return RedirectToAction("AllMovies");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
