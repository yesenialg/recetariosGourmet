namespace Gourmet;
using Gourmet;
public class Celiaco : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Nombre.Equals("cereales"))
                return false;
        }
        return true;
    }
}