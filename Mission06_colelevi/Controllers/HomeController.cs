using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;

        //Pass form to database as context class
        private MovieFormContext movieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieFormContext m)
        {
            _logger = logger;
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
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if(ModelState.IsValid) 
            {
                movieContext.Add(ar); 
                movieContext.SaveChanges(); 
                return View ("Confirmation", ar);
            }
            else {return View();}
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
