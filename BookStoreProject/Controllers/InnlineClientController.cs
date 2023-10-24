using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers
{
    public class InnlineClientController : BaseController
    {
        private readonly IInnlineClientService _innlineClientService;

        public InnlineClientController(IInnlineClientService innlineClientService)
        {
            _innlineClientService = innlineClientService;
        }

        [HttpGet("get-token")]
        public async Task<string> GetTokenAsync()
        {
            return await _innlineClientService.GetTokenAsync();
        }
    }
}
