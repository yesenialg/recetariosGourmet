namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Vegano : IPerfil
{
    public bool RecetaApta(Receta receta) => !receta.Ingredientes.Any(i => i.Tipo.Equals(Tipo.carnes) || i.Tipo.Equals(Tipo.lacteos));
}