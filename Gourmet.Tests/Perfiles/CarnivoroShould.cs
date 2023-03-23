using Xunit;
using Gourmet;
using Gourmet.Perfiles;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;
using Gourmet.Repositories;
using Gourmet.Services.Contracts;
using Gourmet.Services;

public class CarnivoroShould
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

        await ingredienteRecetaService.Add(ingredienteReceta);
        await ingredienteRecetaService.Add(ingredienteReceta2);

        IPerfil carnivoro = new Carnivoro();
        var apta = carnivoro.RecetaApta(receta);
        Assert.True(apta);
    }

    [Fact]
    public async void TestRecetaNoApta()
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

        await ingredienteRecetaService.Add(ingredienteReceta);
        await ingredienteRecetaService.Add(ingredienteReceta2);

        IPerfil carnivoro = new Carnivoro();
        var Noapta = carnivoro.RecetaApta(receta);
        Assert.False(Noapta);
    }
}