using Core;
using Core.Domain;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly AppSettings _appSettings;
        private static List<User> _users = new List<User>() 
        { 
            new User() { Id = 1, Username = "odeon", Password = "1" },
            new User() { Id = 2, Username = "emre", Password = "1" }
        };
        public AuthService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(m => m.Id == id);
        }
    }
}
