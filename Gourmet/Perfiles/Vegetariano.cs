namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Vegetariano : IPerfil
{
    public bool RecetaApta(Receta receta) => !receta.IngredientesReceta.Any(i => i.GrupoAlimentario().Equals(Tipo.carnes));
}