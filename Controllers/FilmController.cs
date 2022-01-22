using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using filmdb.Models;
using System;

namespace filmdb.Controllers
{
    public class FilmController : Controller
    {   

        private readonly IFilmManager _filmManager;

        public FilmController(IFilmManager filmManager){
            _filmManager = filmManager;
        }

        [Route("Films")]
        public IActionResult Index(){
            
            var films = _filmManager.GetFilms();

            
            return View(films);
        }

        // [Route("Films/EditTitle/{id?}/{title?}")]

        public IActionResult Index(int id, string title){
            _filmManager.ChangeTitle(id, title);
            // // var film = new FilmModel();
            // // // film.ID = 1;
            // // film.Title = "Huj";
            // // film.Year = 2137;
            // // manager.AddFilm(film);

            // manager.RemoveFilm(2);


            
            return View();
        }

        [HttpGet]
        [Route("Films/add")]
        public IActionResult Add(){
            return View();
        }

        // 
        // GET: /HelloWorld/

        // public string Index()
        // {
        //     return "This is my default action...";
        // }

        // 
        // GET: /HelloWorld/Welcome/ 

        [HttpPost]
        [Route("Films/add")]
        public IActionResult Add(FilmModel film){
           
            _filmManager.AddFilm(film);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id){
            var film = _filmManager.GetFilm(id);

            return View(film);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id){
            
            try{
                _filmManager.RemoveFilm(id);
                return RedirectToAction("Index");
            }
            catch(Exception){
                return RedirectToAction("Error");
            }

        }

        [HttpGet]
        public IActionResult Edit(int id){
            var film = _filmManager.GetFilm(id);

            return View(film);
        }
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        
    }
}