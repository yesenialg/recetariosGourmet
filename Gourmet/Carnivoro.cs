namespace Gourmet;
using Gourmet;

public class Carnivoro : IPerfil
{

    bool IPerfil.RecetaApta(Receta receta)
    {
        if (receta.cantidadCalorias() > 200)
            foreach (KeyValuePair<Ingrediente, double> ingrediente in receta.Ingredientes)
            {
                if (ingrediente.Key.Tipo.Equals("carnes"))
                    return true;
            }
        return false;
    }
}