using Xunit;
using Gourmet;
public class PerfilShould
{

    [Fact]
    public void TestRecetaAptaCeliaco()
    {

        var vegetales = new Tipo("vegetales");
        var carnes = new Tipo("carnes");

        var unidad = new Unidad("unidad");

        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, unidad, carnes);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var celiaco = new Perfil("celiaco");

        var apta = celiaco.RecetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoAptaCeliaco()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var celiaco = new Perfil("celiaco");

        var Noapta = celiaco.RecetaApta(receta1);

        Assert.False(Noapta);
    }

    [Fact]
    public void TestRecetaAptaCarnivoro()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");
        var carnes = new Tipo("carnes");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, unidad, carnes);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var carnivoro = new Perfil("carnivoro");

        var apta = carnivoro.RecetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoAptaCarnivoro()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var carnivoro = new Perfil("carnivoro");

        var Noapta = carnivoro.RecetaApta(receta1);
        Assert.False(Noapta);
    }

    [Fact]
    public void TestRecetaAptaVegano()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var vegano = new Perfil("vegano");

        var apta = vegano.RecetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoAptaVegano()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");
        var carnes = new Tipo("carnes");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, unidad, carnes);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var vegano = new Perfil("vegano");

        var Noapta = vegano.RecetaApta(receta1);

        Assert.False(Noapta);
    }

    [Fact]
    public void TestRecetaAptaVegetariano()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var vegetariano = new Perfil("vegetariano");

        var apta = vegetariano.RecetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoAptaVegetariano()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");
        var carnes = new Tipo("carnes");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, unidad, carnes);

        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new Dictionary<IngredienteCuantitativo, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var vegetariano = new Perfil("vegetariano");

        var Noapta = vegetariano.RecetaApta(receta1);

        Assert.False(Noapta);
    }
}
