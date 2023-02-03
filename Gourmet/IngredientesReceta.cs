namespace Gourmet;
using Gourmet;

public partial class IngredientesReceta
{
    public long Id { get; set; }
    public long IdIngrediente { get; set; }
    public double CantidadIngrediente { get; set; }
    public long IdReceta { get; set; }

    public virtual IngredienteCuantitativo? IdIngredienteNavigation { get; set; }
    public virtual Receta? IdRecetaNavigation { get; set; }

    public double CalcularCalorias()
    {
        return IdIngredienteNavigation.CalcularCalorias(CantidadIngrediente);
    }

    public bool CompararIngrediente(IngredienteCuantitativo ingrediente)
    {
        return IdIngredienteNavigation.Nombre.Equals(ingrediente.Nombre);
    }

    public long GrupoAlimentario()
    {
        return IdIngredienteNavigation.IdTipo;
    }
}