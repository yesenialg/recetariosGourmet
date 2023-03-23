namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.ContextDB;
using Gourmet.Ingredientes;
using Gourmet.Repositories;
using Gourmet.Services;
using Gourmet.Services.Contracts;

public class Celiaco : IPerfil
{
    private readonly IIngredienteRecetaService _ingredienteRecetaService = new IngredienteRecetaService(new IngredienteRecetaRepository(new DBRecetariosContext()));

    public bool RecetaApta(Receta receta)
    {
        Console.WriteLine(receta.Id);
        var ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(receta.Id).ToList();
        return !ingredientes.Any(i => i.GrupoAlimentario().Result.Equals(Tipo.cereales));
    }
}