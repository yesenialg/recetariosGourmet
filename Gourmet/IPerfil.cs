namespace Gourmet;
using Gourmet;
public interface IPerfil
{
    string Nombre { get; set; }
    bool RecetaApta(Receta receta);
}