namespace Gourmet;
using Gourmet;
using System.Text.Json.Nodes;

public partial class Recetario
{
    public Recetario()
    {
        RecetasRecetarios = new HashSet<RecetasRecetario>();
    }

    public long Id { get; set; }
    public string? Titulo { get; set; }

    public virtual ICollection<RecetasRecetario> RecetasRecetarios { get; set; }

    public int CantidadRecetas() => RecetasRecetarios.Count;
}