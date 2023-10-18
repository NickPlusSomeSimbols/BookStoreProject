using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security;
using System.Security.Claims;
using System.Text;
using BookStoreProjectCore.IdentityAuth;
using BookStoreProjectInfrastructure.Dtos.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreProjectInfrastructure.Data.Services;

public class AuthenticateService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly BasketDataService _basketDataService;

    public AuthenticateService(UserManager<ApplicationUser> userManager, IConfiguration configuration, BasketDataService basketDataService)
    {
        _basketDataService = basketDataService;
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<bool> Register(RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);

        if (userExists != null)
            throw new SecurityException("user with such name already exists");

        ApplicationUser user = new ApplicationUser()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            string errors = "";

            foreach (var error in result.Errors)
                errors += $"\n\n{error.Description}";

            throw new SecurityException(errors);
        }
        if (model.basketId != null)
            await _basketDataService.BindBuyerToBasket(user.Id, model.basketId.Value);

        return true;
    }
    public async Task<LoginResponse> Login(LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.UserName),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var myGuid = Guid.NewGuid();

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            if (model.basketId != 0)
                await _basketDataService.BindBuyerToBasket(user.Id, model.basketId);

            return new LoginResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
        throw new SecurityException("Wrong password");
    }
}