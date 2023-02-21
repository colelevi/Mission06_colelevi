using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_colelevi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_colelevi.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext movieContext { get; set; }
        public HomeController(MovieFormContext m)
        {
            movieContext = m;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories =  movieContext.categories.ToList();
            return View(new ApplicationResponse());
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            // Verify and add to database
            if (ModelState.IsValid) 
            {
                movieContext.Add(ar); 
                movieContext.SaveChanges(); 
                return View ("Confirmation", ar);
            }
            else 
            {
                ViewBag.Categories = movieContext.categories.ToList();
                return View();
            }
        }
        
        public IActionResult ShowMovies()
        {
            var movies = movieContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            
            return View(movies);
        }

        //Action to Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = movieContext.categories.ToList();

            var form = movieContext.responses.Single(x => x.MovieId == id);

            return View("MovieForm", form);
        }
        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            movieContext.Update(ar);
            movieContext.SaveChanges();
            return RedirectToAction("ShowMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var form = movieContext.responses.Single(x => x.MovieId == id);
            return View(form);
        }

        [HttpPost]
            public IActionResult Delete(ApplicationResponse ar)
        {
            movieContext.responses.Remove(ar);
            movieContext.SaveChanges();
            
            return RedirectToAction("ShowMovies");
        }
    }
}
