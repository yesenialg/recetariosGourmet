namespace Gourmet.Ingredientes;

public class IngredienteCuantitativo : Ingrediente
{
    public IngredienteCuantitativo()
    {
        IngredientesReceta = new HashSet<IngredientesReceta>();
    }

    public double CalcularCalorias(double cantidadDeUnidades) => Calorias * cantidadDeUnidades;
}