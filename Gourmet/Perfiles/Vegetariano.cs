namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Vegetariano : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        foreach (IngredientesReceta ingrediente in receta.IngredientesReceta)
        {
            if (ingrediente.GrupoAlimentario().Equals(Tipo.carnes))
                return false;
        }
        return true;
    }
}