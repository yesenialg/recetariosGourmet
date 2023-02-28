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
            foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
            {
                if (ingrediente.Key.Tipo.Equals(Tipo.carnes))
                    return true;
            }
        return false;
    }
}