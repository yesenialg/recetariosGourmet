namespace Gourmet;

public partial class Ingredientes
{
    public Ingredientes()
    {
        IngredientesReceta = new HashSet<IngredientesReceta>();
    }

    public string? Nombre { get; set; }
    public long Id { get; set; }
    public long Calorias { get; set; }
    public long IdTipo { get; set; }
    public long IdUnidad { get; set; }

    public virtual Tipo? IdTipoNavigation { get; set; }
    public virtual Unidad? IdUnidadNavigation { get; set; }

    public virtual ICollection<IngredientesReceta> IngredientesReceta { get; set; }

    public long CalcularCalorias()
    {
        return Calorias;
    }
}