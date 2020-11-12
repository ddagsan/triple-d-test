using Core.Domain;
using Services.Models.Web;

namespace Services.AuthServices
{
    public interface IAuthService
    {
        UserModel ValidateAndGet(string username, string pass);
        User GetUserById(int id);
    }
}