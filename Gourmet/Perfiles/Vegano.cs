namespace Gourmet;
using Gourmet;
public class Vegano : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Equals(Tipo.carnes) || ingrediente.Key.Tipo.Equals(Tipo.lacteos))
                return false;
        }
        return true;
    }
}