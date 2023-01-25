namespace Gourmet;
using Gourmet;

public class Recetario
{
    public string Titulo { get; set; }
    public List<Receta> Recetas { get; set; }

    public Recetario(string titulo, List<Receta> recetas)
    {
        this.Titulo = titulo;
        this.Recetas = recetas;
    }

    public int CantidadRecetas()
    {
        return Recetas.Count;
    }
}