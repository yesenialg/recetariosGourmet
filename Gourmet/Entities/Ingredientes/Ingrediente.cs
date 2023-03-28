namespace Gourmet.Ingredientes;

public partial class Ingrediente
{
    public string? Nombre { get; set; }
    public long Id { get; set; }
    public long Calorias { get; set; }
    public Tipo Tipo { get; set; }
    public Unidad Unidad { get; set; }

    public virtual ICollection<Receta> Recetas { get; set; }
    public virtual List<IngredientesReceta> IngredientesReceta { get; set; }

    public long CalcularCalorias(double cantidadIngrediente) => Calorias;
}