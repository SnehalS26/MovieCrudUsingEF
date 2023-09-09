using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCrudUsingEF.Models;

namespace MovieCrudUsingEF.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext context;
        MovieCrud moviecrud;
        public MovieController(ApplicationDbContext context)
        {
            this.context = context;
            moviecrud = new MovieCrud(this.context);
        }
        // GET: MovieController
        public ActionResult Index()
        {
            return View(moviecrud.GetAllMovies());
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View(moviecrud.GetMovieById(id));
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            try
            {
                var res = moviecrud.AddMovie(movie);
                if(res== 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(moviecrud.GetMovieById(id));
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                var res = moviecrud.UpdateMovie(movie);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(moviecrud.GetMovieById(id));
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var res = moviecrud.DeleteMovie(id);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
