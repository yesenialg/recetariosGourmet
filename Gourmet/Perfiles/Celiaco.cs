namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Celiaco : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        foreach (IngredientesReceta ingrediente in receta.IngredientesReceta)
        {
            if (ingrediente.GrupoAlimentario().Equals(Tipo.cereales))
                return false;
        }
        return true;
    }
}