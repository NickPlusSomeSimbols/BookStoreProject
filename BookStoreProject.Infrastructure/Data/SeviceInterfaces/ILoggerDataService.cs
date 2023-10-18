using BookStoreProjectCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectInfrastructure.Data.SeviceInterfaces
{
    public interface ILoggerDataService
    {
        public Task<bool> DeleteAllLogAsync();
    }
}
