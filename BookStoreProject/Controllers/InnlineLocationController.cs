using BookStoreProjectCore.Model;
using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStoreProjectAPI.Controllers
{
    public class InnlineLocationController : BaseController
    {
        private readonly IInnlineLocationService _innlineLocationService;

        public InnlineLocationController(IInnlineLocationService innlineLocationService)
        {
            _innlineLocationService = innlineLocationService;
        }

        [HttpGet("Location-Get")]
        public async Task<List<InnlineLocationDto>> GetLocation(int clientId, string fromCreationDate, string toCreationDate, int skip, bool isDeleted, int take)
        {
            return await _innlineLocationService.GetLocationAsync(clientId,fromCreationDate,toCreationDate,skip,isDeleted,take);
        }
        [HttpPost("Location-Post")]
        public async Task<string> PostLocation(InnlineLocationDto innlineLocationDto)
        {
            return await _innlineLocationService.PostLocationAsync(innlineLocationDto);
        }
    }
}
