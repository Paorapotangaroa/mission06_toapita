using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        // Post request
        [HttpPost]
        public IActionResult MovieEntry(Movies submission)
        {
            //If what they entered is valid redirect to Index
            if (ModelState.IsValid)
            {
                Movies.Add(submission);
                Movies.SaveChanges();
                //It did not specify which page to return on success to I returned home
                return View("Index");
            }
            else
            {
            //Redirect back to the MovieEntry page and display errors
                return View(submission);
            }
            
        }


    }
}
