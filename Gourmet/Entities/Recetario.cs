namespace Gourmet;

public partial class Recetario
{
    public Recetario()
    {
        Recetas = new HashSet<Receta>();
    }

    public long Id { get; set; }
    public string? Titulo { get; set; }

    public virtual ICollection<Receta> Recetas { get; set; }

    public int CantidadRecetas() => Recetas.Count();
}