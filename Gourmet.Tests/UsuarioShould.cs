using Xunit;
using Gourmet;
using Moq;
using System;

public class UsuarioShould
{

    [Fact]
    public void TestNotificacionActivada()
    {
        Usuario usuario = new Usuario("Ana", "ana@gmail.com");

        Celiaco celiaco = new();

        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

        var ingredientes1 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(pechuga, 1),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var notificar = new Mock<INotificacion>();

        var usuarioPerfil1 = new Mock<UsuarioPerfil>(usuario, celiaco, true, notificar.Object);
        usuarioPerfil1.SetupGet(u => u.Notificar).Returns(true);
        notificar.Setup(u => u.EnviarNotificacion(receta1)).Verifiable();

        var usuariosSuscritos = new List<UsuarioPerfil> { usuarioPerfil1.Object };

        var recetario = new Recetario("Recetario de prueba", new List<Receta>())
        {
            UsuariosSuscritos = usuariosSuscritos
        };

        recetario.AgregarReceta(receta1);

        notificar.Verify(u => u.EnviarNotificacion(receta1), Times.Once);
    }

    [Fact]
    public void TestNotificacionDesactivada()
    {
        Usuario usuario = new Usuario("Ana", "ana@gmail.com");

        Celiaco celiaco = new();

        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

        var ingredientes1 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(pechuga, 1),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var notificar = new Mock<INotificacion>();

        var usuarioPerfil1 = new Mock<UsuarioPerfil>(usuario, celiaco, false, notificar.Object);

        usuarioPerfil1.SetupGet(u => u.Notificar).Returns(false);
        notificar.Setup(u => u.EnviarNotificacion(receta1)).Verifiable();

        var usuariosSuscritos = new List<UsuarioPerfil> { usuarioPerfil1.Object };

        var recetario = new Recetario("Recetario de prueba", new List<Receta>())
        {
            UsuariosSuscritos = usuariosSuscritos
        };

        recetario.AgregarReceta(receta1);

        notificar.Verify(u => u.EnviarNotificacion(receta1), Times.Never);

    }

    [Fact]
    public void TestNoRecibeNotificacion()
    {
        Usuario usuario = new Usuario("Ana", "ana@gmail.com");

        Celiaco celiaco = new();

        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);
        
        var ingredientes1 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(pechuga, 1),
            new IngredienteCantidad(mani, 2),
            new IngredienteCantidad(arroz, 1),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        var notificar = new Mock<INotificacion>();

        var usuarioPerfil1 = new Mock<UsuarioPerfil>(usuario, celiaco, true, notificar.Object);
        usuarioPerfil1.SetupGet(u => u.Notificar).Returns(true);
        notificar.Setup(u => u.EnviarNotificacion(receta1)).Verifiable();

        var usuariosSuscritos = new List<UsuarioPerfil> { usuarioPerfil1.Object };

        var recetario = new Recetario("Recetario de prueba", new List<Receta>())
        {
            UsuariosSuscritos = usuariosSuscritos
        };

        recetario.AgregarReceta(receta1);

        notificar.Verify(u => u.EnviarNotificacion(receta1), Times.Never);
    }
}
