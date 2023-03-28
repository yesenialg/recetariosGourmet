namespace Gourmet.Perfiles;
using Gourmet;
using Gourmet.Ingredientes;

public class Celiaco : IPerfil
{
    public bool RecetaApta(Receta receta) => !receta.Ingredientes.Any(i => i.Tipo.Equals(Tipo.cereales));
}