using Xunit;
using Gourmet;
using System;
using Gourmet.Repositories;
using Gourmet.Repositories.Contracts;
using Gourmet.ContextDB;
using Gourmet.Services.Contracts;
using Gourmet.Services;

public class RecetarioShould 
{
    [Fact]
    public async void TestCrearRecetario()
    {

        IRecetarioService recetarioService = new RecetarioService(new RecetarioRepository(new DBRecetariosContext()));

        var recetario = new Recetario()
        {
            Titulo = "Recetario1"
        };
        await recetarioService.Add(recetario);

        var leerRecetario = await recetarioService.GetById(recetario.Id);

        Assert.Equal("Recetario1", leerRecetario.Titulo);

    }

    [Fact]
    public async void TestActualizarRecetario()
    {

        IRecetarioService recetarioService = new RecetarioService(new RecetarioRepository(new DBRecetariosContext()));

        var recetario = new Recetario()
        {
            Titulo = "Recetario2"
        };
        
        await recetarioService.Add(recetario);

        var idRecetario = recetario.Id;
        recetario.Titulo = "RECETARIO2";

        await recetarioService.Update(recetario);

        var leerRecetario = await recetarioService.GetById(idRecetario);

        Assert.Equal("RECETARIO2", leerRecetario.Titulo);
    }

    [Fact]
    public async void TestLeerRecetario()
    {
        IRecetarioService recetarioService = new RecetarioService(new RecetarioRepository(new DBRecetariosContext()));

        var recetario = new Recetario()
        {
            Titulo = "Recetario3"
        };
        await recetarioService.Add(recetario);

        var leerRecetario = await recetarioService.GetById(recetario.Id);

        Assert.Equal("Recetario3", leerRecetario.Titulo);
    }

    [Fact]
    public async void TestEliminarRecetario()
    {
        IRecetarioService recetarioService = new RecetarioService(new RecetarioRepository(new DBRecetariosContext()));

        var recetario = new Recetario()
        {
            Titulo = "Recetario4"
        };
        await recetarioService.Add(recetario);

        var deleteRecetario = await recetarioService.GetById(recetario.Id);

        await recetarioService.Delete(deleteRecetario.Id);

        var leerRecetario = await recetarioService.GetById(recetario.Id);

        Assert.Null(leerRecetario);
    }

    [Fact]
    public async void TestCantidadRecetas()
    {
        IRecetarioService recetarioService = new RecetarioService(new RecetarioRepository(new DBRecetariosContext()));
        IRecetasRecetarioService recetasRecetarioService = new RecetasRecetarioService(new RecetasRecetarioRepository(new DBRecetariosContext()));

        var recetario = new Recetario()
        {
            Titulo = "Recetario5"
        };
        await recetarioService.Add(recetario);

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
        await recetasRecetarioService.Add(recetarioRecetas);
        await recetasRecetarioService.Add(recetarioRecetas2);

        int cantidad = recetario.CantidadRecetas();

        Assert.Equal(2, cantidad);
    }
}
