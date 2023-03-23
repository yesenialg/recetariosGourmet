using Xunit;
using Gourmet;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;
using Gourmet.Services;
using Gourmet.Repositories;
using Gourmet.Services.Contracts;

public class RecetaShould
{

    [Fact]
    public async void TestCantidadIngredientes()
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
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.libra,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
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
            CantidadIngrediente = 1
        };

        await ingredienteRecetaService.Add(ingredienteReceta);
        await ingredienteRecetaService.Add(ingredienteReceta2);

        int cantidad = receta.CantidadIngredientes();

        Assert.Equal(2, cantidad);
    }


    [Fact]
    public async void TestPresenciaDeIngredientes()
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
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
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

        bool presencia = receta.PresenciaDeIngrediente(ingredienteReceta2.IdIngredienteNavigation);

        Assert.True(presencia);
    }

    [Fact]
    public async void TestPresenciaDeGrupoAlimenticio()
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
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.libra,
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

        bool presencia = receta.PresenciaDeGrupoAlimenticio(Tipo.lacteos);

        Assert.True(presencia);
    }
}
