using Microsoft.Extensions.DependencyInjection;
using SGuF.Application.Common.Interfaces.Base;
using SGuF.Application.Common.Interfaces.Repositories;
using SGuF.Infra.Context;
using SGuF.Infra.Repository;
using SGuF.Infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Infra
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<SGuFDbContext>();

            return services;
        }
    }
}
