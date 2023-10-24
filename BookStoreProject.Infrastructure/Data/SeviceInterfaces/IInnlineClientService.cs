using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProjectInfrastructure.Data.SeviceInterfaces
{
    public interface IInnlineClientService
    {
        public Task<string> GetTokenAsync();
    }
}
