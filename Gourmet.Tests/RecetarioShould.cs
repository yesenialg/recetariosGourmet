using Xunit;
using Gourmet;

public class RecetarioShould 
{

    [Fact]
    public void TestCantidadRecetas()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);
        var cebolla = new IngredienteCuantitativo("Cebolla", 95, Unidad.unidad, Tipo.legumbres);

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

        Assert.Equal(2, recetario.CantidadRecetas());
    }
}
