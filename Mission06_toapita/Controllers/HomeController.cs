using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_toapita.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_toapita.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Create a Movies object attribute that will be a Movies Context Variable
        private MoviesContext Movies { get; set; }
        public HomeController(ILogger<HomeController> logger, MoviesContext moviesContext)
        {
            _logger = logger;
            // Give access to the movies Context class based on the parameter
            Movies = moviesContext;
        }

        // Define some basic routes
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }
        
        //Get request for movie entry
        [HttpGet]
        public IActionResult MovieEntry()
        {
            //Grab all the categories and send them to viewBag for use in rendering
            ViewBag.Categories = Movies.Categories.ToList();
            //Send a new Movie object to the front end
            return View(new Movies());
        }

        // Post request
        [HttpPost]
        public IActionResult MovieEntry(Movies submission)
        {
            //If what they entered is valid redirect to Index
            if (ModelState.IsValid)
            {
                //add the submission
                Movies.Add(submission);
                Movies.SaveChanges();
                //It did not specify which page to return on success to I returned home
                return RedirectToAction("MovieList");
            }
            else
            {
                //Grab all the categories
                ViewBag.Categories = Movies.Categories.ToList();
                //Redirect back to the MovieEntry page and display errors
                return View(submission);
            }
            
        }
        [HttpGet]
        public IActionResult MovieList()
        {
            //Grab all the movies and their associated category objects and send them
            //to the rendering engine
            var movies = Movies.Movies.Include(x => x.Category).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Grab all the categories
            ViewBag.Categories = Movies.Categories.ToList();
            //Grab the single movie associated with the id
            var myMovie = Movies.Movies.Single(x => x.MovieID == id);
            //render the view
            return View("MovieEntry",myMovie);
        }

        [HttpPost]
        public IActionResult Edit(Movies m)
        {
            if (ModelState.IsValid)
            {
                //If the edit is valid update and save
                Movies.Update(m);
                Movies.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                //Grab all the categories
                ViewBag.Categories = Movies.Categories.ToList();
                //send them back to the view
                return View("MovieEntry",m);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Grab only the movie associated with the passed id and render the 
            // deletion confirmation page
            var myMovie = Movies.Movies.Single(x => x.MovieID == id);
            return View(myMovie);
        }

        [HttpPost]
        public IActionResult Delete(Movies m)
        {
            //If they confirmed: Remove the movie and save the change.
            //Redirect to the MovieList
            Movies.Movies.Remove(m);
            Movies.SaveChanges();
            return RedirectToAction("MovieList");
        }


    }
}
