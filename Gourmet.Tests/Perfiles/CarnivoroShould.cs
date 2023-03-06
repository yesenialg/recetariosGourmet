using Xunit;
using Gourmet;
using Gourmet.Perfiles;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;

public class CarnivoroShould
{
    [Fact]
    public void TestRecetaApta()
    {
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
                Tipo = Tipo.carnes,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        IPerfil carnivoro = new Carnivoro();
        var apta = carnivoro.RecetaApta(receta);
        Assert.True(apta);
    }
    [Fact]
    public void TestRecetaNoApta()
    {
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
                Calorias = 30,
                Tipo = Tipo.carnes,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 20,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        IPerfil carnivoro = new Carnivoro();
        var Noapta = carnivoro.RecetaApta(receta);
        Assert.False(Noapta);
    }
}