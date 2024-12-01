using BookstoreA.Data;
using BookstoreA.Models;
using BookstoreA.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BookstoreA.Service

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

        public async Task UpdateAsync(Genre genre)
        {
            bool hasAny = await _context.Genres.AnyAsync(x => x.Id == genre.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }

            try
            {
                _context.Update(genre);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}