namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Vegano : IPerfil
{
    public bool RecetaApta(Receta receta) => !receta.IngredientesReceta.Any(i => i.GrupoAlimentario().Equals(Tipo.carnes) || i.GrupoAlimentario().Equals(Tipo.lacteos));}