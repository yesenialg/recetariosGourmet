﻿using Xunit;
using Gourmet;
using System;

public class CeliacoShould
{
    [Fact]
    public void TestRecetaApta()
    {
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);
        var pechuga = new IngredienteCuantitativo("Pechuga", 115, Unidad.unidad, Tipo.carnes);

        var ingredientes1 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(pechuga, 1),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        IPerfil celiaco = new Celiaco();
        var apta = celiaco.RecetaApta(receta1);
        Assert.True(apta);
    }

    [Fact]
    public void TestRecetaNoApta()
    {

        var mani = new IngredienteCuantitativo("Mani", 5, Unidad.gramos, Tipo.cereales);
        var arroz = new IngredienteCuantitativo("Arroz", 180, Unidad.libra, Tipo.cereales);
        var brocoli = new IngredienteCuantitativo("Brocoli", 145, Unidad.unidad, Tipo.vegetales);

        var ingredientes1 = new List<IngredienteCantidad>
        {
            new IngredienteCantidad(mani, 2),
            new IngredienteCantidad(arroz, 1),
            new IngredienteCantidad(brocoli, 1),
        };
        var receta1 = new Receta("Receta1", ingredientes1);

        IPerfil celiaco = new Celiaco();
        var Noapta = celiaco.RecetaApta(receta1);
        Assert.False(Noapta);
    }
}