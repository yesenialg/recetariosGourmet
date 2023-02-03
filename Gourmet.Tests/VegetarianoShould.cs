using Xunit;
using Gourmet;
public class VegetarianoShould
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
                Nombre = "Cebolla",
                Calorias = 300,
                IdTipo = 3,
                IdUnidad = 1,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Lechuga",
                Calorias = 200,
                IdTipo = 3,
                IdUnidad = 2,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        IPerfil vegetariano = new Vegetariano("vegetariano");
        var apta = vegetariano.RecetaApta(receta);
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
                Nombre = "Cebolla",
                Calorias = 300,
                IdTipo = 3,
                IdUnidad = 1,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Pechuga",
                Calorias = 200,
                IdTipo = 1,
                IdUnidad = 2,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        IPerfil vegetariano = new Vegetariano("vegetariano");
        var Noapta = vegetariano.RecetaApta(receta);
        Assert.False(Noapta);
    }
}
