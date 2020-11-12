using Core.Domain;

namespace Services.AuthServices
{
    public interface IAuthService
    {
        User GetUserById(int id);
    }
}