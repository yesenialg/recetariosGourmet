using Xunit;
using Gourmet;
using Gourmet.Perfiles;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;

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
                Tipo = Tipo.legumbres,
                Unidad = Unidad.libra,
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
                Tipo = Tipo.vegetales,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        IPerfil vegetariano = new Vegetariano();
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
                Tipo = Tipo.legumbres,
                Unidad = Unidad.unidad,
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
                Tipo = Tipo.carnes,
                Unidad = Unidad.unidad,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        IPerfil vegetariano = new Vegetariano();
        var Noapta = vegetariano.RecetaApta(receta);
        Assert.False(Noapta);
    }
}
