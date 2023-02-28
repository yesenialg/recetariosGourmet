namespace Gourmet;
using Gourmet;
public class Vegano : IPerfil
{
    public string Nombre { get; set; }
    public Vegano(string nombre)
    {
        this.Nombre = nombre;
    }
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