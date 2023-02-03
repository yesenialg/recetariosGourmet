using Xunit;
using Gourmet;
using System;

public class RecetarioShould 
{
    [Fact]
    async public void TestCrearRecetario()
    {
        var context = new DBRecetariosContext();

        var recetario = new Recetarios()
        {
            Titulo = "Recetario1"
        };
        context.Recetarios.Add(recetario);
        context.SaveChanges();

        var recetarioRecetas = new RecetasRecetario()
        {
            IdRecetario = recetario.Id,
            IdRecetaNavigation = new Recetas()
            {
                Titulo = "Receta1"
            }
        };
        context.RecetasRecetarios.Add(recetarioRecetas);

        Assert.Equal(2, await context.SaveChangesAsync());
        
    }

    [Fact]
    public void TestActualizarRecetario()
    {
        var context = new DBRecetariosContext();

        var recetario = new Recetarios()
        {
            Titulo = "Recetario2"
        };

        context.Recetarios.Add(recetario);
        context.SaveChanges();

        var result = recetario.EditarRecetario(recetario.Id, "RECETARIO2");
        Assert.Equal(1, result);
    }

    [Fact]
    public void TestLeerRecetario()
    {
        var context = new DBRecetariosContext();

        var recetario = new Recetarios()
        {
            Titulo = "Recetario3"
        };

        context.Recetarios.Add(recetario);
        context.SaveChanges();

        var LeerRecetario = context.Recetarios.Where(s => s.Titulo == "Recetario3").ToList()[0];

        Assert.Equal("Recetario3", LeerRecetario.Titulo);
    }

    [Fact]
    public void TestEliminarRecetario()
    {
        var context = new DBRecetariosContext();

        var recetarioRecetas = new RecetasRecetario()
        {
            IdRecetarioNavigation = new Recetarios()
            {
                Titulo = "Recetario4"
            },
            IdRecetaNavigation = new Recetas()
            {
                Titulo = "Receta"
            }
        };

        context.RecetasRecetarios.Add(recetarioRecetas);
        context.SaveChanges();

        var recetario = context.Recetarios.Where(s => s.Titulo == "Recetario4").ToList()[0];

        context.Recetarios.Remove(recetario);
        Assert.Equal(2, context.SaveChanges());
    }

    [Fact]
    public void TestCantidadRecetas()
    {
        var context = new DBRecetariosContext();

        var recetario = new Recetarios()
        {
            Titulo = "Recetario5"
        };
        context.Recetarios.Add(recetario);
        context.SaveChanges();

        var recetarioRecetas = new RecetasRecetario()
        {
            IdRecetario = recetario.Id,
            IdRecetaNavigation = new Recetas()
            {
                Titulo = "Receta5"
            }
        };
        var recetarioRecetas2 = new RecetasRecetario()
        {
            IdRecetario = recetario.Id,
            IdRecetaNavigation = new Recetas()
            {
                Titulo = "Receta5"
            }
        };
        context.RecetasRecetarios.Add(recetarioRecetas);
        context.RecetasRecetarios.Add(recetarioRecetas2);
        context.SaveChanges();

        int cantidad = recetario.CantidadRecetas();

        Assert.Equal(2, cantidad);
    }
}
