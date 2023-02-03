namespace Gourmet;

public partial class Unidad
{
    public Unidad()
    {
        Ingredientes = new HashSet<Ingredientes>();
    }

    public string? Nombre { get; set; }
    public long Id { get; set; }

    public virtual ICollection<Ingredientes> Ingredientes { get; set; }
}