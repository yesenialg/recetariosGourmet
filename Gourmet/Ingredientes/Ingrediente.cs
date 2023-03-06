namespace Gourmet.Ingredientes;
public enum Tipo
{
    carnes,
    legumbres,
    vegetales,
    cereales,
    lacteos
};

public enum Unidad
{
    gramos,
    libra,
    unidad
}


public partial class Ingrediente
{
    public Ingrediente()
    {
        IngredientesReceta = new HashSet<IngredientesReceta>();
    }

    public string? Nombre { get; set; }
    public long Id { get; set; }
    public long Calorias { get; set; }
    public Tipo Tipo { get; set; }
    public Unidad Unidad { get; set; }


    public virtual ICollection<IngredientesReceta> IngredientesReceta { get; set; }

    public long CalcularCalorias() => Calorias;
}