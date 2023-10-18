using BookStoreProjectCore;
using BookStoreProjectCore.Exceptions;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using BookStoreProjectInfrastructure.Dtos.Storage;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class BookStorageDataService : IBookStorageDataService
    {
        private readonly BookStoreDbContext _context;

        public BookStorageDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<BookStorageDto> GetStorageAsync(int StorageId)
        {
            var bookInStorage = await _context.BookStorages.FirstOrDefaultAsync(i => i.BookStoreId == StorageId);
            if (bookInStorage == null)
            {
                throw new ItemNotFoundException();
            }

            var bookInStorageDto = bookInStorage.Adapt<BookStorageDto>();

            return bookInStorageDto;
        }
        
        public async Task<int> AddBookToStorageAsync(AddBookToStorageDto createRequest)
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

        public async Task<int> UpdateBookToStorageAsync(UpdateBookToStorageDto updateRequest)
        {
            var bookToStorage = await _context.BookStorages.FindAsync(updateRequest.Id);

            if (bookToStorage == null)
            {
                throw new ItemNotFoundException();
            }

            bookToStorage.BookId = updateRequest.BookId;
            bookToStorage.Amount = updateRequest.Amount;
            bookToStorage.BookStoreId = updateRequest.BookStoreId;

            await _context.SaveChangesAsync();

            return bookToStorage.Id;
        }

        public async Task<bool> DeleteBookFromStorageAsync(int id)
        {
            var bookInStorage = await _context.BookStorages.FindAsync(id);

            if (bookInStorage == null)
            {
                throw new ItemNotFoundException();
            }

            _context.BookStorages.Remove(bookInStorage);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
