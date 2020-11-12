using Data;
using Microsoft.Extensions.DependencyInjection;
using Services.AuthServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure
{
    public class DependencyRegistrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDbContext, DefaultDbContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICurrencyService, CsvCurrencyService>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}
