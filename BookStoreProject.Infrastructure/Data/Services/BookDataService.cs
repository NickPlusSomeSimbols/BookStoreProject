using BookStoreProjectCore;
using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Dtos.Book;
using Mapster;
using BookStoreProjectCore.Exceptions;
using BookStoreProjectInfrastructure.Data.SeviceInterfaces;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class BookDataService : IBookDataService
    {
        private readonly BookStoreDbContext _context;

        public BookDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<BookDto> GetBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                throw new ItemNotFoundException();
            }

            var bookDto = book.Adapt<BookDto>();

            return bookDto;
        }

        public async Task<int> CreateBookAsync(CreateBookDto createRequest)
        {
            var book = createRequest.Adapt<Book>();

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task<int> UpdateBookAsync(UpdateBookDto updateRequest)
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
        }
    }
}
