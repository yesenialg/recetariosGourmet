using Xunit;
using Gourmet;

public class UsuarioShould
{

    [Fact]
    public void TestNotificacionActivada()
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

        Dictionary<IngredienteCuantitativo, double> ingredientes2 = new Dictionary<IngredienteCuantitativo, double>
        {
            { pechuga, 1},
            { brocoli, 1},
        };

        var receta2 = new Receta("Receta2", ingredientes2);

        List<Receta> recetas = new List<Receta>() { receta1 };

        var recetario = new Recetario("Recetario1", recetas);

        Usuario usuario1 = new Usuario("Ana", "ana@gmail.com");

        Perfil celiaco = new Perfil("celiaco");

        ISuscritora sus1 = new UsuarioPerfil(usuario1, celiaco, true);

        recetario.SuscribirUsuario(sus1);

        Assert.True(recetario.AgregarReceta(receta2)[sus1]);
    }

    [Fact]
    public void TestNotificacionDesactivada()
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

        Dictionary<IngredienteCuantitativo, double> ingredientes2 = new Dictionary<IngredienteCuantitativo, double>
        {
            { pechuga, 1},
            { brocoli, 1},
        };

        var receta2 = new Receta("Receta2", ingredientes2);

        List<Receta> recetas = new List<Receta>() { receta1 };

        var recetario = new Recetario("Recetario1", recetas);

        Usuario usuario1 = new Usuario("Ana", "ana@gmail.com");

        Perfil celiaco = new Perfil("celiaco");

        ISuscritora sus1 = new UsuarioPerfil(usuario1, celiaco, false);

        recetario.SuscribirUsuario(sus1);

        Assert.Empty(recetario.AgregarReceta(receta2));
    }

    [Fact]
    public void TestNoRecibeNotificacion()
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

        Dictionary<IngredienteCuantitativo, double> ingredientes2 = new Dictionary<IngredienteCuantitativo, double>
        {
            { pechuga, 1},
            { brocoli, 1},
        };

        var receta2 = new Receta("Receta2", ingredientes2);

        List<Receta> recetas = new List<Receta>() { receta1 };

        var recetario = new Recetario("Recetario1", recetas);

        Usuario usuario1 = new Usuario("Ana", "ana@gmail.com");

        Perfil vegetariano = new Perfil("vegetariano");

        ISuscritora sus1 = new UsuarioPerfil(usuario1, vegetariano, true);

        recetario.SuscribirUsuario(sus1);

        Assert.Empty(recetario.AgregarReceta(receta2));
    }
}
