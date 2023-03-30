using Gourmet;
using Gourmet.Perfiles;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;
using Gourmet.Repositories;
using Gourmet.Services.Contracts;
using Gourmet.Services;

public class CarnivoroShould
{
    private readonly IIngredienteRecetaService _ingredienteRecetaService = new IngredienteRecetaService(new IngredienteRecetaRepository(new DBRecetariosContext()));

    [Fact]
    public async void TestRecetaApta()
    {
        var ingredienteReceta = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Pechuga",
                Calorias = 500,
                Tipo = Tipo.carnes,
                Unidad = Unidad.unidad,
            },
            Receta = new Receta() {
                Titulo = "Receta50",
            },
            CantidadIngrediente = 1
        };

        await _ingredienteRecetaService.Add(ingredienteReceta);

        IPerfil carnivoro = new Carnivoro();
        var apta = carnivoro.RecetaApta(ingredienteReceta.Receta);

        Assert.True(apta);
    }

    [Fact]
    public async void TestRecetaNoApta()
    {
        var ingredienteReceta2 = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 20,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            Receta = new Receta()
            {
                Titulo = "Receta50",
            },
            CantidadIngrediente = 2
        };

        await _ingredienteRecetaService.Add(ingredienteReceta2);

        IPerfil carnivoro = new Carnivoro();
        var Noapta = carnivoro.RecetaApta(ingredienteReceta2.Receta);

        Assert.False(Noapta);
    }
}