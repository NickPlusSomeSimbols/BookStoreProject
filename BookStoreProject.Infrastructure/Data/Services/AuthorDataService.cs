using BookStoreProjectCore;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class AuthorDataService
    {
        private readonly BookStoreDbContext _context;

        public AuthorDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }
    }
}
