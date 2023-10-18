using BookStoreProjectInfrastructure.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers
{
    public class LoggerController
    {

        private readonly LoggerDataService _loggerDataService;

        public LoggerController(LoggerDataService loggerDataService)
        {
            _loggerDataService = loggerDataService;
        }

        [HttpDelete("AllLog-Delete")]
        public async Task<bool> DeletAllLog(int id)
        {
            return await _loggerDataService.DeleteAllLogAsync();
        }
    }
}
