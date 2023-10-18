using BookStoreProjectInfrastructure.Dtos.Authentication;

namespace BookStoreProjectInfrastructure.Data.SeviceInterfaces
{
    public interface IAuthenticateService
    {
        public Task<bool> Register(RegisterModel model);
        public Task<LoginResponse> Login(LoginModel model);
    }
}
