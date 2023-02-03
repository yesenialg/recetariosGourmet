namespace Gourmet;
using Gourmet;
public class Carnivoro : IPerfil
{
    public string Nombre { get; set; }
    public Carnivoro(string nombre)
    {
        this.Nombre = nombre;
    }
    public bool RecetaApta(Receta receta)
    {
        if (receta.CantidadCalorias() > 200)
            foreach (IngredientesReceta ingrediente in receta.IngredientesReceta)
            {
                if (ingrediente.GrupoAlimentario().Equals(1))
                    return true;
            }
        return false;
    }
}