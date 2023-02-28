﻿using Xunit;
using Gourmet;
public class VeganoShould
{
    [Fact]
    public void TestRecetaApta()
    {
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad,Tipo.vegetales);
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos,Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra,Tipo.cereales);
        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new()
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);
        IPerfil vegano = new Vegano("vegano");
        var apta = vegano.RecetaApta(receta1);
        Assert.True(apta);
    }
    [Fact]
    public void TestRecetaNoApta()
    {
        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos,Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra,Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad,Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad,Tipo.carnes);
        Dictionary<IngredienteCuantitativo, double> ingredientes1 = new()
        {
            { mani, 10},
            { arroz, 0.5},
            { brocoli, 1},
            { pechuga, 1},
        };
        var receta1 = new Receta("Receta1", ingredientes1);
        IPerfil vegano = new Vegano("vegano");
        var Noapta = vegano.RecetaApta(receta1);
        Assert.False(Noapta);
    }
}