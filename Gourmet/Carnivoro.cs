﻿namespace Gourmet;
using Gourmet;
public class Carnivoro : IPerfil
{
    public bool RecetaApta(Receta receta)
    {
        if (receta.CantidadCalorias() > 200)
            foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
            {
                if (ingrediente.Key.Tipo.Nombre.Equals("carnes"))
                    return true;
            }
        return false;
    }
}