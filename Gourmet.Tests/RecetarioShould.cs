using Xunit;
using Gourmet;
using System;
using Gourmet.Repositories;
using Gourmet.Repositories.Contracts;

public class RecetarioShould 
{
    [Fact]
    async public void TestCrearRecetario()
    {
        IRecetarioRepository recetarioRepository = new RecetarioRepository(new DBRecetariosContext());

        var recetario = new Recetario()
        {
            Titulo = "Recetario1"
        };
        recetarioRepository.InsertRecetario(recetario);

        Assert.Equal(1, recetarioRepository.Save());
        
    }

    [Fact]
    public void TestActualizarRecetario()
    {
        IRecetarioRepository recetarioRepository = new RecetarioRepository(new DBRecetariosContext());

        var recetario = new Recetario()
        {
            Titulo = "Recetario2"
        };
        recetarioRepository.InsertRecetario(recetario);
        recetarioRepository.Save();

        recetario.Titulo = "RECETARIO2";

        recetarioRepository.UpdateRecetario(recetario);
        Assert.Equal(1, recetarioRepository.Save());
    }

    [Fact]
    public void TestLeerRecetario()
    {
        IRecetarioRepository recetarioRepository = new RecetarioRepository(new DBRecetariosContext());

        var recetario = new Recetario()
        {
            Titulo = "Recetario3"
        };
        recetarioRepository.InsertRecetario(recetario);
        recetarioRepository.Save();

        var LeerRecetario = recetarioRepository.GetRecetarioByTitle(recetario.Titulo);

        Assert.Equal("Recetario3", LeerRecetario.Titulo);
    }

    [Fact]
    public void TestEliminarRecetario()
    {
        IRecetarioRepository recetarioRepository = new RecetarioRepository(new DBRecetariosContext());

        var recetario = new Recetario()
        {
            Titulo = "Recetario4"
        };
        recetarioRepository.InsertRecetario(recetario);
        recetarioRepository.Save();

        var deleteRecetario = recetarioRepository.GetRecetarioByTitle(recetario.Titulo);

        recetarioRepository.DeleteRecetario((long)deleteRecetario.Id);
        Assert.Equal(1, recetarioRepository.Save());
    }

    [Fact]
    public void TestCantidadRecetas()
    {
        var context = new DBRecetariosContext();

        var recetario = new Recetario()
        {
            Titulo = "Recetario5"
        };
        context.Recetarios.Add(recetario);
        context.SaveChanges();

        var recetarioRecetas = new RecetasRecetario()
        {
            IdRecetario = recetario.Id,
            IdRecetaNavigation = new Receta()
            {
                Titulo = "Receta5"
            }
        };
        var recetarioRecetas2 = new RecetasRecetario()
        {
            IdRecetario = recetario.Id,
            IdRecetaNavigation = new Receta()
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
