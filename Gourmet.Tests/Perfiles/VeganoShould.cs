using Xunit;
using Gourmet;
using Gourmet.Perfiles;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;
using Gourmet.Services.Contracts;
using Gourmet.Services;
using Gourmet.Repositories;

public class VeganoShould
{
    [Fact]
    public async void TestRecetaApta()
    {
        IRecetaService recetaService = new RecetaService(new RecetaRepository(new DBRecetariosContext()));
        IIngredienteRecetaService ingredienteRecetaService = new IngredienteRecetaService(new IngredienteRecetaRepository(new DBRecetariosContext()));

        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        await recetaService.Add(receta);

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

        await ingredienteRecetaService.Add(ingredienteReceta);
        await ingredienteRecetaService.Add(ingredienteReceta2);

        IPerfil vegano = new Vegano();
        var apta = vegano.RecetaApta(receta);
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

        IPerfil vegano = new Vegano();
        var Noapta = vegano.RecetaApta(receta);
        Assert.False(Noapta);
    }
}