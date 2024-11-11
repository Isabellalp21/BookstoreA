using BookstoreA.Models;
using BookstoreA.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookstoreA.Controllers
{
    public class GenresController : Controller
    {
        private readonly GenreService _service;

        public GenresController(GenreService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAllAsync());
        }

        // GET /genres/create
        public IActionResult Create()
        {
            return View();
        }

        // POST /genres/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre); // Retorna o objeto `genre` para preservar os valores preenchidos
            }

            await _service.InsertAsync(genre); // Corrigido para `InsertAsync`
            return RedirectToAction(nameof(Index));
        }

        // GET Genres/Delete/x
        /*
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _service.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj); 
        }
        */

    }
}
