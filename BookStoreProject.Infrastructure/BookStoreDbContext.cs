using BookStoreProjectCore.IdentityAuth;
using BookStoreProjectCore.Logging;
using BookStoreProjectCore.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreProjectCore
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookSoldReport> BookSoldReports { get; set; }
        public DbSet<BookStorage> BookStorages { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<LogTable> logEntity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasIndex(i => i.AuthorName).IsUnique();

                entity.Property(i => i.AuthorName).IsRequired();
                entity.Property(i => i.BirthDate).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(i => i.Title).IsUnique();

                entity.Property(i => i.Title).IsRequired();
                entity.Property(i => i.Price).IsRequired();
            });

            modelBuilder.Entity<BookStore>(entity =>
            {
                entity.HasIndex(i => i.StoreName).IsUnique();

                entity.Property(i => i.StoreName).IsRequired();
            });

            modelBuilder.Entity<BookSoldReport>(entity =>
            {
                entity.Property(i => i.Income).HasDefaultValue(0); // Optional
                entity.Property(i => i.BookStoreId).IsRequired();
                entity.Property(i => i.SoldBookId).IsRequired();
            });

            modelBuilder.Entity<BookStorage>(entity =>
            {
                entity.HasIndex(i => new { i.BookId, i.BookStoreId }).IsUnique();

                entity.Property(i => i.Amount).HasDefaultValue(0);
                entity.Property(i => i.BookStoreId).IsRequired();
                entity.Property(i => i.BookId).IsRequired();

            });
            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.Property(i => i.BookStorageId).IsRequired();
                entity.Property(i => i.BookId).IsRequired();
            });
            modelBuilder.Entity<LogTable>(entity =>
            {
                entity.Property(i => i.LogUploadTime).IsRequired();
                entity.Property(i => i.Status).IsRequired();
            });
        }
    }
}
