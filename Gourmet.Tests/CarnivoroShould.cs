using Xunit;
using Gourmet;

enum GrupoALimenticio
{
    lacteos,
    carnes,
    legumbres,
    vegetales,
    frutas,
    cereales
}

public class CarnivoroShould
{

    [Fact]
    public void TestRecetaApta()
    {
        var mani = new Ingrediente("Mani", 5, "gramos", GrupoALimenticio.cereales + "");
        var arroz = new Ingrediente("Arroz", 180, "libra", GrupoALimenticio.cereales + "");
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");
        var pechuga = new Ingrediente("Pechuga", 115, "unidad", GrupoALimenticio.carnes + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        IPerfil carnivoro = new Carnivoro();

        var apta = carnivoro.RecetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoApta()
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

        IPerfil carnivoro = new Carnivoro();

        var Noapta = carnivoro.RecetaApta(receta1);
        Assert.False(Noapta);
    }
}
