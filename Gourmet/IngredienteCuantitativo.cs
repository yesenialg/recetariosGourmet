namespace Gourmet;

public class IngredienteCuantitativo : Ingredientes
{
    public IngredienteCuantitativo()
    {
        IngredientesReceta = new HashSet<IngredientesReceta>();
    }

    public double CalcularCalorias(double cantidadDeUnidades)
    {
        return Calorias * cantidadDeUnidades;
    }
}