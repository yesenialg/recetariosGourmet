namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Vegano : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        foreach (IngredientesReceta ingrediente in receta.IngredientesReceta)
        {
            if (ingrediente.GrupoAlimentario().Equals(Tipo.lacteos) || ingrediente.GrupoAlimentario().Equals(Tipo.carnes))
                return false;
        }
        return true;
    }
}