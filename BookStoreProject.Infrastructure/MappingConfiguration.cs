﻿using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Author;
using BookStoreProjectInfrastructure.Dtos.Basket;
using BookStoreProjectInfrastructure.Dtos.Book;
using BookStoreProjectInfrastructure.Dtos.Storage;
using BookStoreProjectInfrastructure.Dtos.Store;
using Mapster;

namespace BookStoreProjectInfrastructure
{
    public class MappingConfiguration
    {
        public static void Configure()
        {
            // BOOK Forward
            TypeAdapterConfig<Book, BookDto>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Title, s => s.Title)
                .Map(d => d.CreationDate, s => s.CreationDate)
                .Map(d => d.Price, s => s.Price);
            TypeAdapterConfig<Book, CreateBookDto>.NewConfig()
                .Map(d => d.Title, s => s.Title)
                .Map(d => d.CreationDate, s => s.CreationDate)
                .Map(d => d.Price, s => s.Price);
            TypeAdapterConfig<Book, UpdateBookDto>.NewConfig()
                .Map(d => d.Title, s => s.Title)
                .Map(d => d.CreationDate, s => s.CreationDate)
                .Map(d => d.Price, s => s.Price);
            //BOOK Backward
            TypeAdapterConfig<BookDto, Book>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.Title, s => s.Title)
                .Map(d => d.CreationDate, s => s.CreationDate)
                .Map(d => d.Price, s => s.Price);
            TypeAdapterConfig<CreateBookDto, Book>.NewConfig()
                .Map(d => d.Title, s => s.Title)
                .Map(d => d.CreationDate, s => s.CreationDate)
                .Map(d => d.Price, s => s.Price);
            TypeAdapterConfig<UpdateBookDto, Book>.NewConfig()
                .Map(d => d.Title, s => s.Title)
                .Map(d => d.CreationDate, s => s.CreationDate)
                .Map(d => d.Price, s => s.Price);
            //AUTHOR Forward
            TypeAdapterConfig<Author, AuthorDto>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.AuthorName, s => s.AuthorName)
                .Map(d => d.BirthDate, s => s.BirthDate)
                .Map(d => d.DeathDate, s => s.DeathDate);
            TypeAdapterConfig<Author, CreateAuthorDto>.NewConfig()
                .Map(d => d.AuthorName, s => s.AuthorName)
                .Map(d => d.BirthDate, s => s.BirthDate)
                .Map(d => d.DeathDate, s => s.DeathDate);
            TypeAdapterConfig<Author, UpdateAuthorDto>.NewConfig()
                .Map(d => d.AuthorName, s => s.AuthorName)
                .Map(d => d.BirthDate, s => s.BirthDate)
                .Map(d => d.DeathDate, s => s.DeathDate);

            //AUTHOR Backward
            TypeAdapterConfig<AuthorDto, Author>.NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.AuthorName, s => s.AuthorName)
                .Map(d => d.BirthDate, s => s.BirthDate)
                .Map(d => d.DeathDate, s => s.DeathDate);
            TypeAdapterConfig<CreateAuthorDto, Author>.NewConfig()
                .Map(d => d.AuthorName, s => s.AuthorName)
                .Map(d => d.BirthDate, s => s.BirthDate)
                .Map(d => d.DeathDate, s => s.DeathDate);
            TypeAdapterConfig<UpdateAuthorDto, Author>.NewConfig()
                .Map(d => d.AuthorName, s => s.AuthorName)
                .Map(d => d.BirthDate, s => s.BirthDate)
                .Map(d => d.DeathDate, s => s.DeathDate);
            //BASKET Forward
            TypeAdapterConfig<AddBasketItemDto, BasketItem>.NewConfig()
                .Map(d => d.Amount, s => s.Amount)
                .Map(d => d.BookStorageId, s => s.BookStorageId)
                .Map(d => d.BookId, s => s.BookId);
            TypeAdapterConfig<BasketItemDto, BasketItem>.NewConfig()
                .Map(d => d.Amount, s => s.Amount)
                .Map(d => d.BookStorageId, s => s.BookStorageId)
                .Map(d => d.BookId, s => s.BookId);
            TypeAdapterConfig<UpdateBasketItemDto, BasketItem>.NewConfig()
                .Map(d => d.Amount, s => s.Amount);
            //BASKET Backward
            TypeAdapterConfig<BasketItem, BasketItemDto>.NewConfig()
                .Map(d => d.Amount, s => s.Amount)
                .Map(d => d.BookStorageId, s => s.BookStorageId)
                .Map(d => d.BookId, s => s.BookId);
        }
    }
}
