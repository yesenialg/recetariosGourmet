using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;
using Gourmet.Repositories;
using Gourmet.Services.Contracts;
using Gourmet.Services;
using Microsoft.EntityFrameworkCore;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace GourmetApi.Extensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection RegistrarServicios(this IServiceCollection services)
        {
            services.AddDbContext<DBRecetariosContext>(options =>
            options.UseSqlite(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString));
            
            services.AddTransient<IRecetarioRepository, RecetarioRepository>();

            services.AddTransient<IRecetarioService, RecetarioService>();

            return services;
        }
    }
}
