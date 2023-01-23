using Xunit;
using Gourmet;

public class RecetarioShould 
{

    [Fact]
    public void TestCantidadRecetas()
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
        var cn = new Unidad("cantidad necesaria");

        var mani = new Ingrediente("Mani", 5, gramos, cereales);
        var arroz = new Ingrediente("Arroz", 180, libra, cereales);
        var brocoli = new Ingrediente("Brocoli", 145, unidad, vegetales);
        var pechuga = new Ingrediente("Pechuga", 115, unidad, carnes);
        var cebolla = new Ingrediente("Cebolla", 95, unidad, legumbres);

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
