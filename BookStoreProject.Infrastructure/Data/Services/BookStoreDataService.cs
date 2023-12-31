﻿using BookStoreProjectCore;
using BookStoreProjectCore.Exceptions;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using BookStoreProjectInfrastructure.Dtos.Book;
using BookStoreProjectInfrastructure.Dtos.Store;
using Mapster;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class BookStoreDataService : IBookStoreDataService
    {
        private readonly BookStoreDbContext _context;

        public BookStoreDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<BookStoreDto> GetBookStoreAsync(int id)
        {
            var bookStore = await _context.BookStores.FindAsync(id);

            if (bookStore == null)
            {
                throw new ItemNotFoundException();
            }

            var bookStoreDto = bookStore.Adapt<BookStoreDto>();

            return bookStoreDto;
        }

        public async Task<int> CreateBookStoreAsync(CreateBookStoreDto createRequest)
        {
            var bookStore = createRequest.Adapt<BookStore>();

            await _context.BookStores.AddAsync(bookStore);
            await _context.SaveChangesAsync();

            return bookStore.Id;
        }

        public async Task<int> UpdateBookStoreAsync(UpdateBookStoreDto updateRequest)
        {
            var bookStore = await _context.BookStores.FindAsync(updateRequest.Id);

            if (bookStore == null)
            {
                throw new ItemNotFoundException();
            }

            bookStore.StoreName = updateRequest.StoreName;

            await _context.SaveChangesAsync();

            return bookStore.Id;
        }

        public async Task<bool> DeleteBookStoreAsync(int id)
        {
            var bookStore = await _context.BookStores.FindAsync(id);

            if (bookStore == null)
            {
                throw new ItemNotFoundException();
            }

            _context.BookStores.Remove(bookStore);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
