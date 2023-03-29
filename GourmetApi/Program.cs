using Gourmet.ContextDB;
using GourmetApi.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBRecetariosContext>();

builder.Services.RegistrarServicios();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GourmetAPI v1");
    });
}

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
//Conflicting method/path combination "GET api/Recetarios" for actions - GourmetApi.Controllers.RecetarioController.GetAll (GourmetApi),GourmetApi.Controllers.RecetarioController.GetReecetasDeRecetario(GourmetApi).Actions require a unique method/path combination for Swagger/OpenAPI 3.0. Use ConflictingActionsResolver as a workaround