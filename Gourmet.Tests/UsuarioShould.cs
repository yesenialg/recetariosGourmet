using Xunit;
using Gourmet;
using Moq;

public class UsuarioShould
{

    [Fact]
    public void TestNotificacionActivada()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

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

        Celiaco celiaco = new("celiaco");

        Mock<INotificacion> notificar = new Mock<INotificacion>();
        notificar.Setup(a => a.EnviarNotificacion(receta2)).Returns(true);
        
        UsuarioPerfil sus1 = new UsuarioPerfil(usuario1, celiaco, true, notificar.Object);

        recetario.SuscribirUsuario(sus1);

        Assert.True(recetario.AgregarReceta(receta2)[sus1]);
    }

    [Fact]
    public void TestNotificacionDesactivada()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

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

        Celiaco celiaco = new("celiaco");

        Mock<INotificacion> notificar = new Mock<INotificacion>();
        notificar.Setup(a => a.EnviarNotificacion(receta2)).Returns(true);

        UsuarioPerfil sus1 = new UsuarioPerfil(usuario1, celiaco, false, notificar.Object);

        recetario.SuscribirUsuario(sus1);

        Assert.Empty(recetario.AgregarReceta(receta2));
    }

    [Fact]
    public void TestNoRecibeNotificacion()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

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

        Vegetariano vegetariano = new("vegetariano");
        
        Mock<INotificacion> notificar = new Mock<INotificacion>();
        notificar.Setup(a => a.EnviarNotificacion(receta2)).Returns(true);

        UsuarioPerfil sus1 = new UsuarioPerfil(usuario1, vegetariano, true, notificar.Object);

        recetario.SuscribirUsuario(sus1);

        Assert.Empty(recetario.AgregarReceta(receta2));
    }
}
