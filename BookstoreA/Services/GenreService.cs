using BookstoreA.Data;
using BookstoreA.Models;
using BookstoreA.Services.Exceptions;
using BookstoreA.Data;
using BookstoreA.Models;
using BookstoreA.Services.Exceptions;
using BookstoreA.Services;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Bookstore.Services
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
        public async Task<Genre> FindByIdEagerAsync(int id)
        {
            return await _context.Genres.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Genre> FindByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Genre obj = await _context.Genres.FindAsync(id);
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        // POST: Genres/Edit/x
        public async Task UpdateAsync(Genre genre)
        {
            // Confere se tem alguém com esse Id
            bool hasAny = await _context.Genres.AnyAsync(x => x.Id == genre.Id);
            // Se não tiver, lança exceção de NotFound.
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            // Tenta atualizar
            try
            {
                _context.Update(genre);
                await _context.SaveChangesAsync();
            }
            // Se não der, captura a exceção lançada
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

    }
}