using System.ComponentModel.DataAnnotations;

namespace BookStoreProjectInfrastructure.Dtos.Authentication;

public record RegisterModel
{
    public int? basketId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}