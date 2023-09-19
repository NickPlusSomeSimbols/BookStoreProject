using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreProject.Model;
using Microsoft.EntityFrameworkCore;

namespace BookStoreProjectCore
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(i => i.Date).IsRequired();
                entity.Property(i => i.Price).IsRequired();
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasOne(o => o.Order)
                    .WithMany(i => i.Items)
                    .HasForeignKey(o => o.OrderId);

                entity.Property(i => i.Name).IsRequired();
                entity.Property(i => i.Name).HasMaxLength(50);
                entity.Property(i => i.Price).IsRequired();
                entity.Property(i => i.Quantity).IsRequired();
            });

            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.HasOne(b => b.Basket)
                    .WithMany(i => i.Items)
                    .HasForeignKey(b => b.BasketId);

                entity.Property(i => i.Name).IsRequired();
                entity.Property(i => i.Name).HasMaxLength(50);
                entity.Property(i => i.Price).IsRequired();
                entity.Property(i => i.Quantity).IsRequired();
                entity.HasIndex(i => i.CatalogItemId);
            });

            modelBuilder.Entity<CatalogItem>(entity =>
            {
                entity.Property(i => i.Name).IsRequired();
                entity.Property(i => i.Name).HasMaxLength(50);
                entity.Property(i => i.Description).IsRequired();
                entity.Property(i => i.Description).HasMaxLength(200);
                entity.Property(i => i.Price).IsRequired();
                entity.Property(i => i.Quantity).IsRequired();
            });
        }
    }
}
