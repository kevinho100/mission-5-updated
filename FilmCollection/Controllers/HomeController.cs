using Microsoft.AspNetCore.Mvc;
using FilmCollection.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext movieContext { get; set; }

        public HomeController(MovieApplicationContext x)
        {
            movieContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Category = movieContext.Category.ToList();

            return View();
        }


        [HttpPost]
        public IActionResult Movies(ApplicationResponse mv)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(mv);
                movieContext.SaveChanges();

                return View("Confirmation", mv);
            }
            else //if invalid
            {
                ViewBag.Category = movieContext.Category.ToList();
                return View(mv);
            }
 

        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = movieContext.Responses
                .Include(x => x.Category)
                .ToList();
     

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int movieid)
        {
            ViewBag.Category = movieContext.Category.ToList();

            var application = movieContext.Responses.Single(x => x.MovieID == movieid);

            return View("Movies", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse mv)
        {
            movieContext.Update(mv);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }


        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            
            var application = movieContext.Responses.Single(x => x.MovieID == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse mv)
        {
            movieContext.Responses.Remove(mv);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
