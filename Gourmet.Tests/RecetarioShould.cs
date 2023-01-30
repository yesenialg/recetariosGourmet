using Xunit;
using Gourmet;

public class RecetarioShould 
{

    [Fact]
    public void TestCantidadRecetas()
    {

        var carnes = new Tipo("carnes");
        var legumbres = new Tipo("legumbres");
        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, unidad, carnes);
        var cebolla = new IngredienteCuantitativo("Cebolla", 95, unidad, legumbres);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        Dictionary<IngredienteCuantitativo, double> ingredientes2 = new Dictionary<IngredienteCuantitativo, double>
        {
            { pechuga, 1},
            { cebolla, 1},
            { brocoli, 1},
        };
        var receta2 = new Receta("Receta2", ingredientes2);

        List<Receta> recetas = new() { receta1, receta2 };
        var recetario = new Recetario("Recetario1", recetas);

        int cantidad = recetario.CantidadRecetas();

        Assert.Equal(2, cantidad);
    }
}
