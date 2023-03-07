namespace Gourmet;
using Gourmet;
public class Vegetariano : IPerfil
{
    public bool RecetaApta(Receta receta) => !receta.IngredientesCantidad.Any(i => i.Ingrediente.Tipo.Equals(Tipo.carnes));
}