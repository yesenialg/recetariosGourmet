namespace Gourmet;
using Gourmet.Ingredientes;

public partial class IngredientesReceta
{
    public long Id { get; set; }
    public long IdIngrediente { get; set; }
    public double CantidadIngrediente { get; set; }
    public long IdReceta { get; set; }

    public virtual IngredienteCuantitativo? IdIngredienteNavigation { get; set; }
    public virtual Receta? IdRecetaNavigation { get; set; }

    public double CalcularCalorias() => IdIngredienteNavigation.CalcularCalorias(CantidadIngrediente);

    public bool CompararIngrediente(IngredienteCuantitativo ingrediente) => IdIngredienteNavigation.Nombre.Equals(ingrediente.Nombre);

    public Tipo GrupoAlimentario() => IdIngredienteNavigation.Tipo;
}