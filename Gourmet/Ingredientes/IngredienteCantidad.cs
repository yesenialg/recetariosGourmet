namespace Gourmet;

public class IngredienteCantidad
{
    public IngredienteCuantitativo Ingrediente { get; set; }
    public double Cantidad { get; set; }
    public IngredienteCantidad(IngredienteCuantitativo ingrediente, double cantidad)
    {
        this.Ingrediente = ingrediente;
        this.Cantidad = cantidad;
    }

    public double CalcularCalorias() => Ingrediente.CalcularCalorias(Cantidad);

    public bool CompararIngrediente(IngredienteCuantitativo ingrediente) => Ingrediente.Nombre.Equals(ingrediente.Nombre);

    public Tipo GrupoAlimentario() => Ingrediente.Tipo;
}
