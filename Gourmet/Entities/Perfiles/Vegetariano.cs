namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Vegetariano : IPerfil
{
    public bool RecetaApta(Receta receta) => !receta.Ingredientes.Any(i => i.Tipo.Equals(Tipo.carnes));
}