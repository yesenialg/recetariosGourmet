namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.ContextDB;
using Gourmet.Ingredientes;
using Gourmet.Repositories;
using Gourmet.Services;
using Gourmet.Services.Contracts;

public class Carnivoro : IPerfil
{
    private readonly IIngredienteRecetaService _ingredienteRecetaService = new IngredienteRecetaService(new IngredienteRecetaRepository(new DBRecetariosContext()));
    public bool RecetaApta(Receta receta)
    {
        var ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(receta.Id).ToList();
        if (receta.CantidadCalorias() > 200)
            return ingredientes.Any(i => i.GrupoAlimentario().Result.Equals(Tipo.carnes));
        return false;
    }
}