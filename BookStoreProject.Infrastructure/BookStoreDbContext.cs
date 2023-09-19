using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreProjectCore.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStoreProjectCore
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookSoldReport> BookSoldReports { get; set; }
        public DbSet<BookStorage> BookStorages { get; set; }
        public DbSet<BookStore> BookStores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(i => i.AuthorName).IsRequired();
                entity.Property(i => i.BirthDate).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(i => i.Title).IsRequired();
                entity.Property(i => i.Price).IsRequired();

                entity.HasMany(i => i.Authors)
                    .WithMany(i => i.Books);
            });

            modelBuilder.Entity<BookStore>(entity =>
            {
                

                entity.Property(i => i.StoreName).IsRequired();
            });

            modelBuilder.Entity<BookSoldReport>(entity =>
            {
                entity.Property(i => i.Income).HasDefaultValue(0);
            });

            modelBuilder.Entity<BookStorage>(entity =>
            {
                entity.Property(i => i.Amount).HasDefaultValue(0);
            });
        }
    }
}
