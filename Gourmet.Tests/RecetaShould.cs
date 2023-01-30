using Xunit;
using Gourmet;

public class RecetaShould
{

    [Fact]
    public void TestCantidadIngredientes()
    {
        var lacteos = new Tipo("lacteos");
        var carnes = new Tipo("carnes");
        var legumbres = new Tipo("legumbres");
        var vegetales = new Tipo("vegetales");
        var frutas = new Tipo("frutas");
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

        int cantidad = receta1.cantidadIngredientes();

        Assert.Equal(3, cantidad);
    }

    [Fact]
    public void TestCantidadCalorias()
    {
        var lacteos = new Tipo("lacteos");
        var carnes = new Tipo("carnes");
        var legumbres = new Tipo("legumbres");
        var vegetales = new Tipo("vegetales");
        var frutas = new Tipo("frutas");
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

        double cantidad = receta1.cantidadCalorias();

        Assert.Equal(285, cantidad);
    }

    [Fact]
    public void TestPresenciaDeIngredientes()
    {

        var lacteos = new Tipo("lacteos");
        var carnes = new Tipo("carnes");
        var legumbres = new Tipo("legumbres");
        var vegetales = new Tipo("vegetales");
        var frutas = new Tipo("frutas");
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

        bool cantidad = receta1.presenciaDeIngrediente(brocoli);

        Assert.Equal(true, cantidad);
    }

    [Fact]
    public void TestPresenciaDeGrupoAlimenticio()
    {

        var lacteos = new Tipo("lacteos");
        var carnes = new Tipo("carnes");
        var legumbres = new Tipo("legumbres");
        var vegetales = new Tipo("vegetales");
        var frutas = new Tipo("frutas");
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

        bool cantidad = receta1.presenciaDeGrupoAlimenticio(vegetales);

        Assert.Equal(true, cantidad);
    }
}
