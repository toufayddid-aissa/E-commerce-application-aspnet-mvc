using E_commerce_application.Data;
using E_commerce_application.Data.Services;
using System.Data.Entity;
using E_commerce_application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_commerce_application.Data.ViewModel;

namespace E_commerce_application.Controllers
{
    public class MoviesController : Controller
    {
        private IMovieService _service;
        public MoviesController(IMovieService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var movies = await _service.GetAllAsync(n => n.Cinema);
            return View(movies);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _service.GetByIdAsync(id);
            return View(movie);
        }
        public async Task<IActionResult>  Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            var NewMovie = new MovieVM()
            {
                Id = data.Id,
                Name = data.Name,
                Price = data.Price,
                ImageURL = data.ImageURL,
                ProducerId = data.ProducerId,
                CinemaId = data.CinemaId,
                Description = data.Description,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategorie = data.MovieCategorie,
                ActorsId = data.Actors_Movies.Select(n => n.ActorID).ToList()

            };
            var response = await _service.NewDropDownVM();

            ViewBag.ActorId = new SelectList(response.Actors, "Id", "FullName");
            ViewBag.ProducerId = new SelectList(response.Producers, "Id", "FullName");
            ViewBag.CinemaId = new SelectList(response.Cinemas, "Id", "Name");
            return View(NewMovie);

        }
        [HttpPost]
        public  async Task<IActionResult> Edit(int id, MovieVM movie)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateMovieAsync(id, movie);
                return RedirectToAction(nameof(Index));
            }
            var response = await _service.NewDropDownVM();

            ViewBag.ActorId = new SelectList(response.Actors, "Id", "FullName");
            ViewBag.ProducerId = new SelectList(response.Producers, "Id", "FullName");
            ViewBag.CinemaId = new SelectList(response.Cinemas, "Id", "Name");
            return View(movie);
        }
        public async Task<IActionResult> Create()
        {
            var response = await _service.NewDropDownVM();

            ViewBag.ActorId = new SelectList(response.Actors, "Id", "FullName");
            ViewBag.ProducerId = new SelectList(response.Producers, "Id", "FullName");
            ViewBag.CinemaId = new SelectList(response.Cinemas, "Id", "Name");


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieVM data)
        {
            if (!ModelState.IsValid)
            {
                var response = await _service.NewDropDownVM();

                ViewBag.ActorId = new SelectList(response.Actors, "Id", "FullName");
                ViewBag.ProducerId = new SelectList(response.Producers, "Id", "FullName");
                ViewBag.CinemaId = new SelectList(response.Cinemas, "Id", "Name");


                return View(data);

            }
            await _service.AddMovies(data);
            return RedirectToAction(nameof(Index));
        }
        public  async Task<IActionResult> Filter(string data)
        {
            var movies = await _service.GetAllAsync(n => n.Cinema);
            if(string.IsNullOrEmpty(data)) return View("Index" , movies);
            var searchString = movies.Where(n => n.Name.Contains(data) || n.Description.Contains(data));
            return View("Index", searchString);


        }
    }
}
