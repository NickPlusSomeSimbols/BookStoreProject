using System;
using System.Net;

namespace BookStoreProjectInfrastructure.Dtos.Authentication;

public record LoginResponse
{
    public string? Token { get; set; } 
    public DateTime Expiration { get; set; } 
}