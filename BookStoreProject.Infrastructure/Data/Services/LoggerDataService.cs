using BookStoreProjectCore;
using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectInfrastructure.Data.Services
{
    public class LoggerDataService : ILoggerDataService
    {
        private readonly BookStoreDbContext _context;

        public LoggerDataService(BookStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> DeleteAllLogAsync()
        {
            _context.Database.ExecuteSqlRaw("TRUNCATE TABLE logEntity");

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
