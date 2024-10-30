using Microsoft.EntityFrameworkCore;
using SGuF.Application;
using SGuF.Infra;
using SGuF.Infra.Context;
using System.Configuration;

namespace SGuF.Web
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages();

            services.AddDbContext<SGuFDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            services.AddApplication();
            services.AddInfra();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddRazorPages().AddRazorRuntimeCompilation();


        }



        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment env);
        void ConfigureServices(IServiceCollection services);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStatup<TSartup>(this WebApplicationBuilder builder) where TSartup : class
        {
            var startup = Activator.CreateInstance(typeof(TSartup), builder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs invalida");

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app, app.Environment);

            app.Run();

            return builder;
        }
    }
}

