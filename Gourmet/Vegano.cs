﻿namespace Gourmet;
using Gourmet;
public class Vegano : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Nombre.Equals("carnes") || ingrediente.Key.Tipo.Nombre.Equals("lacteos"))
                return false;
        }
        return true;
    }
}