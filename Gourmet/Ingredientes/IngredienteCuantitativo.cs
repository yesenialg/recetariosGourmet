namespace Gourmet;

public class IngredienteCuantitativo : Ingrediente
{
    public IngredienteCuantitativo(string nombre, int calorias, Unidad unidad, Tipo tipo) 
        : base(nombre, calorias, unidad, tipo)
    {}

    public double CalcularCalorias(double cantidadDeUnidades) => Calorias * cantidadDeUnidades;
}