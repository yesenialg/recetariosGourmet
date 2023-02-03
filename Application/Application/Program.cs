// See https://aka.ms/new-console-template for more information
using Gourmet;
using Microsoft.EntityFrameworkCore;

var context = new DBRecetariosContext();

var receta = new Receta()
{
    Titulo = "Receta50"
};
context.Recetas.Add(receta);
context.SaveChanges();

var ingredienteReceta = new IngredientesReceta()
{
    IdIngredienteNavigation = new IngredienteCuantitativo()
    {
        Nombre = "Pechuga",
        Calorias = 300,
        IdTipo = 1,
        IdUnidad = 1,
    },
    IdReceta = receta.Id,
    CantidadIngrediente = 1
};

var ingredienteReceta2 = new IngredientesReceta()
{
    IdIngredienteNavigation = new IngredienteCuantitativo()
    {
        Nombre = "Avena",
        Calorias = 200,
        IdTipo = 6,
        IdUnidad = 2,
    },
    IdReceta = receta.Id,
    CantidadIngrediente = 2
};

context.IngredientesReceta.Add(ingredienteReceta);
context.IngredientesReceta.Add(ingredienteReceta2);
context.SaveChanges();

IPerfil celiaco = new Celiaco("celiaco");
var Noapta = celiaco.RecetaApta(receta);
Console.WriteLine(Noapta);
