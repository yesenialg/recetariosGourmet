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
        foreach (IngredientesReceta ingrediente in receta.IngredientesReceta)
        {
            if (ingrediente.GrupoAlimentario().Equals(1) || ingrediente.GrupoAlimentario().Equals(2))
                return false;
        }
        return true;
    }
}