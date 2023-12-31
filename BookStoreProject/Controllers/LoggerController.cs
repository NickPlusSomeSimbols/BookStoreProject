﻿using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers
{
    public class LoggerController
    {

        private readonly ILoggerDataService _loggerDataService;

        public LoggerController(ILoggerDataService loggerDataService)
        {
            _loggerDataService = loggerDataService;
        }

        [HttpDelete("AllLog-Delete")]
        public async Task<bool> DeletAllLog()
        {
            return await _loggerDataService.DeleteAllLogAsync();
        }
    }
}
