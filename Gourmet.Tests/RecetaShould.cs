using Xunit;
using Gourmet;

public class RecetaShould
{

    [Fact]
    public void TestCantidadIngredientes()
    {
        var mani = new Ingrediente("Mani", 5, "gramos", GrupoALimenticio.cereales + "");
        var arroz = new Ingrediente("Arroz", 180, "libra", GrupoALimenticio.cereales + "");
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
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
        var mani = new Ingrediente("Mani", 5, "gramos", GrupoALimenticio.cereales + "");
        var arroz = new Ingrediente("Arroz", 180, "libra", GrupoALimenticio.cereales + "");
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
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
        var mani = new Ingrediente("Mani", 5, "gramos", GrupoALimenticio.cereales + "");
        var arroz = new Ingrediente("Arroz", 180, "libra", GrupoALimenticio.cereales + "");
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
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
        var mani = new Ingrediente("Mani", 5, "gramos", GrupoALimenticio.cereales + "");
        var arroz = new Ingrediente("Arroz", 180, "libra", GrupoALimenticio.cereales + "");
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        bool cantidad = receta1.presenciaDeGrupoAlimenticio(GrupoALimenticio.vegetales+"");

        Assert.Equal(true, cantidad);
    }
}
