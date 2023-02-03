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
        foreach(IngredientesReceta ingrediente in receta.IngredientesReceta)
        {
            if (ingrediente.GrupoAlimentario().Equals(1))
                return false;
        }
        return true;
    }
}