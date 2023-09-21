using BookStoreProjectCore;
using BookStoreProjectCore.Exceptions;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Book;
using BookStoreProjectInfrastructure.Dtos.Storage;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class BookStorageDataService
    {
        private readonly BookStoreDbContext _context;

        public BookStorageDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }
        /*public async Task<BookStorageDto> GetStorageAsync(int StorageId)
        {
            var bookStorage = await _context.BookStorages.FirstOrDefaultAsync(i => i.BookStoreId == StorageId);
            if (bookStorage == null)
            {
                throw new ItemNotFoundException();
            }

            var bookStorageDto = bookStorage.Adapt<BookStorageDto>();

            return bookStorageDto;
        }
        
        public async Task<int> AddBookToStoreAsync(AddBookToStorageDto createRequest)
        {
            var addBookToStorage = new BookStorage
            {
                BookId = createRequest.BookId,
                Amount = createRequest.Amount,
                BookStoreId = createRequest.BookStoreId,
            };

            _context.BookStorages.Add(addBookToStorage);
            await _context.SaveChangesAsync();

            return addBookToStorage.Id;
        }

        public async Task<int> UpdateBookToStoreAsync(UpdateBookStoreDto updateRequest)
        {

        }

        public async Task<bool> DeleteBookFromStoreAsync(int id)
        {

        }*/
    }
}
