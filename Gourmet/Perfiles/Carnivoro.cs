namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Carnivoro : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        if (receta.CantidadCalorias() > 200)
            foreach (IngredientesReceta ingrediente in receta.IngredientesReceta)
            {
                if (ingrediente.GrupoAlimentario().Equals(Tipo.carnes))
                    return true;
            }
        return false;
    }
}