﻿// <auto-generated />
using System;
using BookStoreProjectCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreProjectInfrastructure.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    partial class BookStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookSoldReportId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookSoldReportId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.BookSoldReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Income")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BookSoldReports");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.BookStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BookStoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("BookStoreId")
                        .IsUnique();

                    b.ToTable("BookStorages");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.BookStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookSoldReportId")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookSoldReportId")
                        .IsUnique();

                    b.ToTable("BookStores");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("BookStoreProjectCore.Model.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreProjectCore.Model.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.Book", b =>
                {
                    b.HasOne("BookStoreProjectCore.Model.BookSoldReport", null)
                        .WithMany("SoldBooks")
                        .HasForeignKey("BookSoldReportId");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.BookStorage", b =>
                {
                    b.HasOne("BookStoreProjectCore.Model.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreProjectCore.Model.BookStore", "BookStore")
                        .WithOne("BookStorage")
                        .HasForeignKey("BookStoreProjectCore.Model.BookStorage", "BookStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookStore");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.BookStore", b =>
                {
                    b.HasOne("BookStoreProjectCore.Model.BookSoldReport", "BookSoldReport")
                        .WithOne("BookStore")
                        .HasForeignKey("BookStoreProjectCore.Model.BookStore", "BookSoldReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookSoldReport");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.BookSoldReport", b =>
                {
                    b.Navigation("BookStore")
                        .IsRequired();

                    b.Navigation("SoldBooks");
                });

            modelBuilder.Entity("BookStoreProjectCore.Model.BookStore", b =>
                {
                    b.Navigation("BookStorage")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
