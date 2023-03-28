// <snippet_all>
using System.Data.Common;
using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;
using Gourmet.Repositories;
using Gourmet.Services.Contracts;
using Gourmet.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var appBuilder = WebApplication.CreateBuilder(args);
var services = appBuilder.Services;

// Create open SqliteConnection so EF won't automatically close it.
services.AddSingleton<DbConnection>(container =>
{
    var connection = new SqliteConnection("Data Source=C:\\Users\\ylopez\\AppData\\Local\\DBRecetarios.db");
    connection.Open();

    return connection;
});

services.AddDbContext<DBRecetariosContext>((container, options) =>
{
    var connection = container.GetRequiredService<DbConnection>();
    options.UseSqlite(connection);
});

// <snippet2>
services.AddScoped<IRecetaRepository, RecetaRepository>();
services.AddScoped<IIngredienteRepository, IngredienteRepository>();
services.AddScoped<IIngredienteRecetaRepository, IngredienteRecetaRepository>();

services.AddScoped<IRecetaService, RecetaService>();
services.AddScoped<IIngredienteService, IngredienteService>();
services.AddScoped<IIngredienteRecetaService, IngredienteRecetaService>();
// </snippet2>

using var app = appBuilder.Build();

app.Run();

public partial class Program { }
// </snippet_all>