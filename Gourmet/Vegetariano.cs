namespace Gourmet;
using Gourmet;
public class Vegetariano : IPerfil
{
    public string Nombre { get; set; }
    public Vegetariano(string nombre)
    {
        this.Nombre = nombre;
    }
    public bool RecetaApta(Receta receta)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Nombre.Equals("carnes"))
                return false;
        }
        return true;
    }
}