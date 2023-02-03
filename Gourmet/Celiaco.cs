namespace Gourmet;
using Gourmet;
public class Celiaco : IPerfil
{
    public string Nombre { get; set; }
    public Celiaco(string nombre)
    {
        this.Nombre = nombre;
    }
    public bool RecetaApta(Receta receta)
    {
        foreach (IngredientesReceta ingrediente in receta.IngredientesReceta)
        {
            if (ingrediente.GrupoAlimentario().Equals(6))
                return false;
        }
        return true;
    }
}