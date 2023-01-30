﻿using Xunit;
using Gourmet;
public class CarnivoroShould
{
    [Fact]
    public void TestRecetaApta()
    {
        var carnes = new Tipo("carnes");
        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, unidad, carnes);
        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new()
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);
        IPerfil carnivoro = new Carnivoro("carnivoro");
        var apta = carnivoro.RecetaApta(receta1);
        Assert.True(apta);
    }
    [Fact]
    public void TestRecetaNoApta()
    {

        var vegetales = new Tipo("vegetales");
        var cereales = new Tipo("cereales");

        var gramos = new Unidad("gramos");
        var libra = new Unidad("libra");
        var unidad = new Unidad("unidad");

        var mani = new IngredienteCuantitativo("Mani", 5, gramos, cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, libra, cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, unidad, vegetales);
        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new()
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);
        IPerfil carnivoro = new Carnivoro("carnivoro");
        var Noapta = carnivoro.RecetaApta(receta1);
        Assert.False(Noapta);
    }
}