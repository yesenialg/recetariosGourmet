using Gourmet;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;
using Gourmet.Services;
using Gourmet.Repositories;
using Gourmet.Services.Contracts;

public class RecetaShould
{
    private readonly IRecetaService _recetaService;
    private readonly IIngredienteRecetaService _ingredienteRecetaService;


    public RecetaShould()
    {
        _recetaService = new RecetaService(new RecetaRepository(new DBRecetariosContext()));
        _ingredienteRecetaService = new IngredienteRecetaService(new IngredienteRecetaRepository(new DBRecetariosContext()));
    }

    [Fact]
    public async void TestCantidadIngredientes()
    {
        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        await _recetaService.Add(receta);

        var ingredienteReceta = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.libra,
            },
            RecetaId = receta.Id,
            CantidadIngrediente = 2
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            RecetaId = receta.Id,
            CantidadIngrediente = 1
        };

        await _ingredienteRecetaService.Add(ingredienteReceta);
        await _ingredienteRecetaService.Add(ingredienteReceta2);

        IEnumerable<IngredientesReceta> ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(receta.Id);
        int cantidad = ingredientes.Count();

        Assert.Equal(2, cantidad);
    }


    [Fact]
    public async void TestPresenciaDeIngredientes()
    {
        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        await _recetaService.Add(receta);

        var ingredienteReceta = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.unidad,
            },
            RecetaId = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            RecetaId = receta.Id,
            CantidadIngrediente = 2
        };

        await _ingredienteRecetaService.Add(ingredienteReceta);
        await _ingredienteRecetaService.Add(ingredienteReceta2);

        IEnumerable<IngredientesReceta> ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(receta.Id);
        bool presencia = ingredientes.Any(i => i.PresenciaDeIngrediente(ingredienteReceta2.Ingrediente));

        Assert.True(presencia);
    }

    [Fact]
    public async void TestPresenciaDeGrupoAlimenticio()
    {
        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        await _recetaService.Add(receta);

        var ingredienteReceta = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Avena",
                Calorias = 300,
                Tipo = Tipo.cereales,
                Unidad = Unidad.libra,
            },
            RecetaId = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                Tipo = Tipo.lacteos,
                Unidad = Unidad.unidad,
            },
            RecetaId = receta.Id,
            CantidadIngrediente = 2
        };

        await _ingredienteRecetaService.Add(ingredienteReceta);
        await _ingredienteRecetaService.Add(ingredienteReceta2);


        IEnumerable<IngredientesReceta> ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(receta.Id);
        bool presencia = ingredientes.Any(i => i.PresenciaDeGrupoAlimenticio(Tipo.lacteos));


        Assert.True(presencia);
    }
}
