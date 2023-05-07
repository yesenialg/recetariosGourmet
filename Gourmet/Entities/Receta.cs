namespace Gourmet;
using System.Collections.Generic;

public partial class Receta
{
    public Receta()
    {
        Recetarios = new HashSet<Recetario>();
    }

    public long Id { get; set; }
    public string? Titulo { get; set; }


    public virtual ICollection<Recetario> Recetarios { get; set; }



}