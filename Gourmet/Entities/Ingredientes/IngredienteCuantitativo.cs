namespace Gourmet.Ingredientes;

public class IngredienteCuantitativo : Ingrediente
{
    public double CalcularCalorias(double cantidadDeUnidades) => Calorias * cantidadDeUnidades;
}