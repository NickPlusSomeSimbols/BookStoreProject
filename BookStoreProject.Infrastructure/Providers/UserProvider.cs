using Microsoft.AspNetCore.Http;

namespace BookStoreProjectInfrastructure.Providers;

public class UserProvider
{
    public string GetUsername()
    {
        var user = new HttpContextAccessor().HttpContext?.User;

        if (user.Identity != null && user.Identity.IsAuthenticated != true)
        {
            return string.Empty;
        }

        return user.Identity.Name;
    }
}