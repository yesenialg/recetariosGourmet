using Xunit;
using Gourmet;

public class RecetaShould
{

    [Fact]
    public void TestCantidadIngredientes()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);

        var ingredientes = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(mani, 10),
            new IngredienteCantidad(arroz, 0.5),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes);

        Assert.Equal(3, receta1.CantidadIngredientes());
    }

    [Fact]
    public void TestCantidadCalorias()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);

        var ingredientes = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(mani, 10),
            new IngredienteCantidad(arroz, 0.5),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes);

        Assert.Equal(285, receta1.CantidadCalorias());
    }

    [Fact]
    public void TestPresenciaDeIngredientes()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);

        var ingredientes = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(mani, 10),
            new IngredienteCantidad(arroz, 0.5),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes);

        Assert.True(receta1.PresenciaDeIngrediente(brocoli));
    }

    [Fact]
    public void TestPresenciaDeGrupoAlimenticio()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);

        var ingredientes = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(mani, 10),
            new IngredienteCantidad(arroz, 0.5),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes);

        Assert.True(receta1.PresenciaDeGrupoAlimenticio(Tipo.vegetales));
    }
}
