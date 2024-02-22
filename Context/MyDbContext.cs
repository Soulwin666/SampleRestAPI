using Microsoft.EntityFrameworkCore;
using SampleRestAPI.Model;
using System.Data;

namespace SampleRestAPI.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Model.Book> Books { get; set; }

        public DbSet<Model.Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure BookId as an identity column
            modelBuilder.Entity<Book>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Sales>()
               .HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
    }
}