using Microsoft.EntityFrameworkCore;
using SampleRestAPI.Model;
using System.Data;

namespace SampleRestAPI.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> oombu) : base(oombu)
        {

        }

        public DbSet<Model.Book> Books { get; set; }
    }
}
