using BookstoreA.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreA.Data
{
	public class  BookstoreContext : DbContext
	{
		public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
		{
		}

		public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("book"); // Mapeia a entidade para a tabela correta
        }

    }


}

