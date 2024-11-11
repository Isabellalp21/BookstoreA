using BookstoreA.Data;
using BookstoreA.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreA.Services
{
    public class GenreService
    {
        private readonly BookstoreContext _context;

        public GenreService(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> FindAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task InsertAsync(Genre genre)
        {
            _context.Add(genre);
            await _context.SaveChangesAsync();
        }

           }
}
