
using BookstoreA.Data;
using BookstoreA.Models;

namespace BookstoreA.Services
{
	public class GenreService
	{
		private readonly BookstoreContext _context;
		public GenreService(BookstoreContext context)
		{
			_context = context;
		}
		public List<Genre> FindAll()
		{
			return _context.Genres.ToList();
		}

        internal async Task<string?> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        internal async Task FindByIdAsync(int value)
        {
            throw new NotImplementedException();
        }
    }
}