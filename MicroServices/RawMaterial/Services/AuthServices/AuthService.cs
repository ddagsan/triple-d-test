using Core;
using Core.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Models.Web;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

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

        public UserModel ValidateAndGet(string username, string pass)
        {
            var retVal = new UserModel();
            var user = _users.SingleOrDefault(m => m.Username == username && m.Password == pass);
            if (user == null)
                return null;
            else
                retVal.Username = user.Username;

            // Authentication(Yetkilendirme) başarılı ise JWT token üretilir.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            retVal.Token = tokenHandler.WriteToken(token);
            return retVal;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(m => m.Id == id);
        }
    }
}
