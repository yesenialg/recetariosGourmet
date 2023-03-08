namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Carnivoro : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        if (receta.CantidadCalorias() > 200)
            return receta.IngredientesReceta.Any(i => i.GrupoAlimentario().Equals(Tipo.carnes));
        return false;
    }
}