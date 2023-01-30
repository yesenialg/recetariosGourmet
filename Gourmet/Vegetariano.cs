namespace Gourmet;
using Gourmet;
public class Vegetariano : IPerfil
{
    bool IPerfil.RecetaApta(Receta receta)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Nombre.Equals("carnes"))
                return false;
        }
        return true;
    }
}