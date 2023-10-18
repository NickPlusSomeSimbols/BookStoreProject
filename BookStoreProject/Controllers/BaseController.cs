using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase 
{
    public async Task SendLogToDb()
    {

    }
}