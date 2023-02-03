namespace Gourmet;

public class IngredienteCuantitativo : Ingrediente
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