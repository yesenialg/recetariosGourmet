namespace Gourmet;
using Gourmet;

public class Celiaco : IPerfil
{

    bool IPerfil.RecetaApta(Receta receta)
    {
        foreach (KeyValuePair<Ingrediente, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Equals("cereales"))
                return false;
        }
        return true;
    }
}