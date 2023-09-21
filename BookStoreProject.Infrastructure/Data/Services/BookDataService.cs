using BookStoreProjectCore;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Book;
using Mapster;
using BookStoreProjectCore.Exceptions;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class BookDataService
    {
        private readonly BookStoreDbContext _context;

        public BookDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        /*public async Task<BookStorageDto> GetBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new ItemNotFoundException();
            }

            // You can use AutoMapper or manually map the Book entity to a BookDto.
            var bookDto = book.Adapt<BookStorageDto>();

            return bookDto;
        }

        public async Task<int> CreateBookAsync(CreateBookStoreDto createRequest)
        {
            var book = createRequest.Adapt<Book>();

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> UpdateBookAsync(UpdateBookStoreDto updateRequest)
        {
            var book = await _context.Books.FindAsync(updateRequest.Id);
            if (book == null)
            {
                throw new ItemNotFoundException();
            }

            book.Title = updateRequest.Title;
            book.CreationDate = updateRequest.CreationDate;
            book.Price = updateRequest.Price;

            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new ItemNotFoundException();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }*/
    }
}
