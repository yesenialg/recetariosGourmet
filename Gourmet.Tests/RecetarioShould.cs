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

public class RecetarioShould 
{

    [Fact]
    public void TestCantidadRecetas()
    {
        var mani = new Ingrediente("Mani", 5, "gramos", GrupoALimenticio.cereales + "");
        var arroz = new Ingrediente("Arroz", 180, "libra", GrupoALimenticio.cereales + "");
        var brocoli = new Ingrediente("Brocoli", 145, "unidad", GrupoALimenticio.vegetales + "");
        var pechuga = new Ingrediente("Pechuga", 115, "unidad", GrupoALimenticio.carnes + "");
        var cebolla = new Ingrediente("Cebolla", 95, "unidad", GrupoALimenticio.legumbres + "");

        Dictionary<Ingrediente, double> ingredientes1 = new Dictionary<Ingrediente, double>
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        Dictionary<Ingrediente, double> ingredientes2 = new Dictionary<Ingrediente, double>
        {
            { pechuga, 1},
            { cebolla, 1},
            { brocoli, 1},
        };
        var receta2 = new Receta("Receta2", ingredientes2);

        List<Receta> recetas = new List<Receta>() { receta1, receta2 };
        var recetario = new Recetario("Recetario1", recetas);

        int cantidad = recetario.cantidadRecetas();

        Assert.Equal(2, cantidad);


    }
}
