using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;
using Gourmet.Repositories;
using Gourmet.Services;
using Gourmet.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gourmet.Tests
{
  
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DBRecetariosContext>(options =>
            options.UseInMemoryDatabase(databaseName: "TestingDB"));

            services.AddScoped<IRecetaRepository, RecetaRepository>();
            services.AddScoped<IIngredienteRepository, IngredienteRepository>();
            services.AddScoped<IIngredienteRecetaRepository, IngredienteRecetaRepository>();

            services.AddTransient<IRecetaService, RecetaService>();
            services.AddTransient<IIngredienteService, IngredienteService>();
            services.AddTransient<IIngredienteRecetaService, IngredienteRecetaService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            // TODO: add your code.
        }
    }
}
