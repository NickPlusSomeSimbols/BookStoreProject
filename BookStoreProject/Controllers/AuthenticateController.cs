using BookStoreProjectInfrastructure.Data.SeviceInterfaces;
using BookStoreProjectInfrastructure.Dtos.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectAPI.Controllers;

[AllowAnonymous]
public class AuthenticateController : BaseController
{
    private readonly IAuthenticateService _authenticateService;

    public AuthenticateController(IAuthenticateService authenticateService)
    {
        _authenticateService = authenticateService;
    }

    [HttpPost]
    [Route("Register")]
    public Task<bool> Register(RegisterModel model)
    {
        return _authenticateService.Register(model);
    }

    [HttpPost]
    [Route("Login")]
    public Task<LoginResponse> Login(LoginModel model)
    {
        return _authenticateService.Login(model);
    }
}