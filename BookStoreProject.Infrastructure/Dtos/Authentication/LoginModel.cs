using System.ComponentModel.DataAnnotations;

namespace BookStoreProjectInfrastructure.Dtos.Authentication;

public record LoginModel
{
    public int basketId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}