﻿using Xunit;
using Gourmet;
public class CarnivoroShould
{
    [Fact]
    public void TestRecetaApta()
    {
        var context = new DBRecetariosContext();

        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        context.Recetas.Add(receta);
        context.SaveChanges();

        var ingredienteReceta = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Pechuga",
                Calorias = 300,
                IdTipo = 1,
                IdUnidad = 1,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 200,
                IdTipo = 2,
                IdUnidad = 2,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        IPerfil carnivoro = new Carnivoro("carnivoro");
        var apta = carnivoro.RecetaApta(receta);
        Assert.True(apta);
    }
    [Fact]
    public void TestRecetaNoApta()
    {
        var context = new DBRecetariosContext();

        var receta = new Receta()
        {
            Titulo = "Receta50"
        };
        context.Recetas.Add(receta);
        context.SaveChanges();

        var ingredienteReceta = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Pechuga",
                Calorias = 30,
                IdTipo = 1,
                IdUnidad = 1,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 1
        };

        var ingredienteReceta2 = new IngredientesReceta()
        {
            IdIngredienteNavigation = new IngredienteCuantitativo()
            {
                Nombre = "Leche",
                Calorias = 20,
                IdTipo = 2,
                IdUnidad = 2,
            },
            IdReceta = receta.Id,
            CantidadIngrediente = 2
        };

        context.IngredientesReceta.Add(ingredienteReceta);
        context.IngredientesReceta.Add(ingredienteReceta2);
        context.SaveChanges();

        IPerfil carnivoro = new Carnivoro("carnivoro");
        var Noapta = carnivoro.RecetaApta(receta);
        Assert.False(Noapta);
    }
}