﻿using Gourmet;
using Gourmet.Perfiles;
using Gourmet.Ingredientes;
using Gourmet.ContextDB;
using Gourmet.Services.Contracts;
using Gourmet.Services;
using Gourmet.Repositories;

public class CeliacoShould
{
    private readonly IIngredienteRecetaService _ingredienteRecetaService = new IngredienteRecetaService(new IngredienteRecetaRepository(new DBRecetariosContext()));

    [Fact]
    public async void TestRecetaApta()
    {
        var ingredienteReceta = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Pechuga",
                Calorias = 300,
                Tipo = Tipo.carnes,
                Unidad = Unidad.unidad,
            },
            Receta = new Receta()
            {
                Titulo = "Receta50"
            },
            CantidadIngrediente = 1
        };

        await _ingredienteRecetaService.Add(ingredienteReceta);

        IPerfil celiaco = new Celiaco();

        var apta = celiaco.RecetaApta(ingredienteReceta.Receta);
        Assert.True(apta);
    }

    [Fact]
    public async void TestRecetaNoApta()
    {
        var ingredienteReceta2 = new IngredientesReceta()
        {
            Ingrediente = new IngredienteCuantitativo()
            {
                Nombre = "Avena",
                Calorias = 200,
                Tipo = Tipo.cereales,
                Unidad = Unidad.libra,
            },
            Receta = new Receta()
            {
                Titulo = "Receta50"
            },
            CantidadIngrediente = 2
        };

        await _ingredienteRecetaService.Add(ingredienteReceta2);

        IPerfil celiaco = new Celiaco();

        var Noapta = celiaco.RecetaApta(ingredienteReceta2.Receta);

        Assert.False(Noapta);
    }
}