using BookStoreProjectCore;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class BookDataService
    {
        private readonly BookStoreDbContext _context;

        public BookDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }
    }
}
