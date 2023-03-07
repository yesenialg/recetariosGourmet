namespace Gourmet;
using Gourmet;
public class Celiaco : IPerfil
{
    public bool RecetaApta(Receta receta) => !receta.IngredientesCantidad.Any(i => i.Ingrediente.Tipo.Equals(Tipo.cereales));
}