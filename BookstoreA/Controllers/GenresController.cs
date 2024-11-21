using BookstoreA.Data;
using BookstoreA.Models;
using BookstoreA.Services;
using Microsoft.AspNetCore.Mvc;
namespace BookstoreA.Controllers
{
    public class GenresController : Controller
    {
        private readonly GenreService _service;
        public GenresController(GenreService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.FindAll());
        }
    }
}