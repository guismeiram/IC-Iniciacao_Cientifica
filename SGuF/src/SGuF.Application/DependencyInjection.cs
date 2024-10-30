using Microsoft.Extensions.DependencyInjection;
using SGuF.Application.Photo.Command.CreatePhoto;
using SGuF.Application.Photo.Queries.GetPhotoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.AddMediatR(cf => cf.RegisterServicesFromAssemblies(typeof(CreatePhotoCommand.Handler).GetTypeInfo().Assembly));
         
            return services;
        }
    }
}
