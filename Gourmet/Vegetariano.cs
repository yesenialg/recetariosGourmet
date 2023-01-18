namespace Gourmet;
using Gourmet;

public class Vegetariano : IPerfil
{

    bool IPerfil.RecetaApta(Receta receta)
    {
        foreach (KeyValuePair<Ingrediente, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Equals("carnes"))
                return false;
        }
        return true;
    }
}