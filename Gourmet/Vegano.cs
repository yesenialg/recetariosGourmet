namespace Gourmet;
using Gourmet;

public class Vegano : IPerfil
{

    bool IPerfil.RecetaApta(Receta receta)
    {
        foreach (KeyValuePair<Ingrediente, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Equals("carnes") || ingrediente.Key.Tipo.Equals("lacteos"))
                return false;
        }
        return true;
    }
}