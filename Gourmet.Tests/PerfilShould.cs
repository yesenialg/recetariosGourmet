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

enum Perfiles
{
    carnivoro,
    celiaco,
    vegano,
    vegetariano
}

public class PerfilShould
{

    [Fact]
    public void TestRecetaAptaCeliaco()
    {
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");
        var pechuga = new Ingrediente("Pechuga", 115, "unidad", GrupoALimenticio.carnes + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
        {
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var celiaco = new Perfil(Perfiles.celiaco + "");

        var apta = celiaco.recetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoAptaCeliaco()
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

        var celiaco = new Perfil(Perfiles.celiaco + "");

        var Noapta = celiaco.recetaApta(receta1);

        Assert.False(Noapta);
    }

    [Fact]
    public void TestRecetaAptaCarnivoro()
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

        var carnivoro = new Perfil(Perfiles.carnivoro + "");

        var apta = carnivoro.recetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoAptaCarnivoro()
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

        var carnivoro = new Perfil(Perfiles.carnivoro + "");

        var Noapta = carnivoro.recetaApta(receta1);
        Assert.False(Noapta);
    }

    [Fact]
    public void TestRecetaAptaVegano()
    {
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");
        var mani = new Ingrediente("Mani", 5, "gramos", GrupoALimenticio.cereales + "");
        var arroz = new Ingrediente("Arroz", 180, "libra", GrupoALimenticio.cereales + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var vegano = new Perfil(Perfiles.vegano + "");

        var apta = vegano.recetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoAptaVegano()
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

        var vegano = new Perfil(Perfiles.vegano + "");

        var Noapta = vegano.recetaApta(receta1);

        Assert.False(Noapta);
    }

    [Fact]
    public void TestRecetaAptaVegetariano()
    {
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");
        var mani = new Ingrediente("Mani", 5, "gramos", GrupoALimenticio.cereales + "");
        var arroz = new Ingrediente("Arroz", 180, "libra", GrupoALimenticio.cereales + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var vegetariano = new Perfil(Perfiles.vegetariano + "");

        var apta = vegetariano.recetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoAptaVegetariano()
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

        var vegetariano = new Perfil(Perfiles.vegetariano + "");

        var Noapta = vegetariano.recetaApta(receta1);

        Assert.False(Noapta);
    }
}
