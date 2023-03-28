using Gourmet;
using Gourmet.Repositories;
using Gourmet.ContextDB;
using Gourmet.Services.Contracts;
using Gourmet.Services;

public class RecetarioShould
{

    private readonly IRecetarioService _recetarioService = new RecetarioService(new RecetarioRepository(new DBRecetariosContext()));

    [Fact]
    public async void TestCrearRecetario()
    {
        var recetario = new Recetario()
        {
            Titulo = "Recetario1"
        };
        await _recetarioService.Add(recetario);

        var leerRecetario = await _recetarioService.GetById(recetario.Id);


        Assert.Equal("Recetario1", leerRecetario.Titulo);
    }

    [Fact]
    public async void TestActualizarRecetario()
    {
        var recetario = new Recetario()
        {
            Titulo = "Recetario2"
        };

        await _recetarioService.Add(recetario);

        var idRecetario = recetario.Id;
        recetario.Titulo = "RECETARIO2";

        await _recetarioService.Update(recetario);

        var leerRecetario = await _recetarioService.GetById(idRecetario);

        Assert.Equal("RECETARIO2", leerRecetario.Titulo);
    }

    [Fact]
    public async void TestLeerRecetario()
    {
        var recetario = new Recetario()
        {
            Titulo = "Recetario3"
        };
        await _recetarioService.Add(recetario);

        var leerRecetario = await _recetarioService.GetById(recetario.Id);

        Assert.Equal("Recetario3", leerRecetario.Titulo);
    }

    [Fact]
    public async void TestEliminarRecetario()
    {
        var recetario = new Recetario()
        {
            Titulo = "Recetario4"
        };
        await _recetarioService.Add(recetario);

        var id = recetario.Id;

        var deleteRecetario = await _recetarioService.GetById(recetario.Id);

        await _recetarioService.Delete(deleteRecetario.Id);

        var leerRecetario = await _recetarioService.GetById(id);

        Assert.Null(leerRecetario);
    }

    [Fact]
    public async void TestCantidadRecetas()
    {
        var recetario = new Recetario()
        {
            Titulo = "Recetario5",
            Recetas = {
                    new Receta() {
                        Titulo = "Receta5"
                    },
                    new Receta(){
                        Titulo = "Receta6"
                    }
                }
        };
        await _recetarioService.Add(recetario);

        int cantidad = recetario.CantidadRecetas();

        Assert.Equal(2, cantidad);
    }
}
