﻿using System;
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
            var movies = _moviesContext.responses.Include(x => x.Rating).Include(x => x.Category).Include(x => x.Director).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Rating = _moviesContext.ratings.ToList();
            ViewBag.Director = _moviesContext.directors.ToList();
            ViewBag.Category = _moviesContext.categories.ToList();
            
            return View();
        }
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
                return View();
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
