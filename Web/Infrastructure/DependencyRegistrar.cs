using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Infrastructure
{
    public class DependencyRegistrar
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDbContext, DefaultDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}
