using Xunit;
using Gourmet;
public class VeganoShould
{
    [Fact]
    public void TestRecetaApta()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");


        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad,vegetales);
        var mani = new IngredienteCuantitativo("Mani", 5, gramos,cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra,cereales);
        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new()
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);
        IPerfil vegano = new Vegano();
        var apta = vegano.RecetaApta(receta1);
        Assert.True(apta);
    }
    [Fact]
    public void TestRecetaNoApta()
    {

        var carnes = new Tipo("carnes");
        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");


        var mani = new IngredienteCuantitativo("Mani", 5, gramos,cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra,cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad,vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, unidad,carnes);
        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new()
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);
        IPerfil vegano = new Vegano();
        var Noapta = vegano.RecetaApta(receta1);
        Assert.False(Noapta);
    }
}