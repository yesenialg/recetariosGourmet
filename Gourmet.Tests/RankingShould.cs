using Xunit;
using Gourmet;

public class RankingShould
{

    [Fact]
    public void TestSumarPuntosActivado()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

        var ingredientes1 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(pechuga, 1),
            new IngredienteCantidad(mani, 2),
            new IngredienteCantidad(arroz, 1),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var ingredientes2 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(pechuga, 1),
            new IngredienteCantidad(brocoli, 1),
        };

        var receta2 = new Receta("Receta2", ingredientes2);

        List<Receta> recetas = new List<Receta>() { receta2 };

        var recetario = new Recetario("Recetario1", recetas);

        Ranking ranking1 = new("Ranking1", true);
        ranking1.AgregarReceta(receta1);


        recetario.SuscribirRanking(ranking1);
        recetario.AgregarReceta(receta1);

        Assert.Equal(10, ranking1.Recetas[receta1]);
    }

    [Fact]
    public void TestSumarPuntosDesactivado()
    {

        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

        var ingredientes1 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(pechuga, 1),
            new IngredienteCantidad(mani, 2),
            new IngredienteCantidad(arroz, 1),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var ingredientes2 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(pechuga, 1),
            new IngredienteCantidad(brocoli, 1),
        };

        var receta2 = new Receta("Receta2", ingredientes2);

        List<Receta> recetas = new List<Receta>() { receta2 };

        var recetario = new Recetario("Recetario1", recetas);

        Ranking ranking1 = new("Ranking1", true);
        ranking1.AgregarReceta(receta1);
        ranking1.CambiarEstado(false);

        recetario.SuscribirRanking(ranking1);
        recetario.AgregarReceta(receta1);

        Assert.Equal(0, ranking1.Recetas[receta1]);
    }
}
