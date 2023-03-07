namespace Gourmet;
using Gourmet;
public class Vegano : IPerfil
{
    public bool RecetaApta(Receta receta) => !receta.IngredientesCantidad.Any(i => i.Ingrediente.Tipo.Equals(Tipo.carnes) || i.Ingrediente.Tipo.Equals(Tipo.lacteos));
}