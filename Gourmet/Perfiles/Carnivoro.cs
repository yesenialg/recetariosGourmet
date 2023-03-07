namespace Gourmet;
using Gourmet;
public class Carnivoro : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        if (receta.CantidadCalorias() > 200)
            return receta.IngredientesCantidad.Any(i => i.Ingrediente.Tipo.Equals(Tipo.carnes));
        return false;
    }
}