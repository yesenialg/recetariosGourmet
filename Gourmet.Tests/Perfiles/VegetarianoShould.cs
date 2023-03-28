using Gourmet;
using Gourmet.ContextDB;
using Gourmet.Ingredientes;
using Gourmet.Perfiles;
using Gourmet.Repositories;
using Gourmet.Services;
using Gourmet.Services.Contracts;

public class VegetarianoShould
{
    private readonly IIngredienteRecetaService _ingredienteRecetaService = new IngredienteRecetaService(new IngredienteRecetaRepository(new DBRecetariosContext()));

    [Fact]
    public async void TestRecetaApta()
    {
        var ingredienteReceta = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Cebolla",
                Calorias = 300,
                Tipo = Tipo.legumbres,
                Unidad = Unidad.libra,
            },
            Receta = new Receta()
            {
                Titulo = "Receta50"
            },
            CantidadIngrediente = 1
        };

        await _ingredienteRecetaService.Add(ingredienteReceta);

        IPerfil vegetariano = new Vegetariano();
        var apta = vegetariano.RecetaApta(ingredienteReceta.Receta);

        Assert.True(apta);
    }

    [Fact]
    public async void TestRecetaNoApta()
    {
        var ingredienteReceta2 = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Pechuga",
                Calorias = 200,
                Tipo = Tipo.carnes,
                Unidad = Unidad.unidad,
            },
            Receta = new Receta()
            {
                Titulo = "Receta50"
            },
            CantidadIngrediente = 2
        };

        await _ingredienteRecetaService.Add(ingredienteReceta2);

        IPerfil vegetariano = new Vegetariano();
        var Noapta = vegetariano.RecetaApta(ingredienteReceta2.Receta);
        Assert.False(Noapta);
    }
}
