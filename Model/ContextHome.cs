using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_Api.Model
{
    public class ContextHome : DbContext
    {
        public ContextHome(DbContextOptions<ContextHome> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
    }

}
