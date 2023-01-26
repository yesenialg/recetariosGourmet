namespace Gourmet;
using Gourmet;

public class Perfil
{
    public string Nombre { get; set; }

    public Perfil(string nombre)
    {
        this.Nombre = nombre;
    }

    public bool RecetaApta(Receta receta)
    {
        if (this.Nombre == "carnivoro")
        {
            return this.Carnivoro(receta);
        }
        else if (this.Nombre == "celiaco")
        {
            return this.Celiaco(receta);
        }
        else if (this.Nombre == "vegano")
        {
            return this.Vegano(receta);
        }
        else if (this.Nombre == "vegetariano")
        {
            return this.Vegetariano(receta);
        }
        else
        {
            return true;
        }
    }

    bool Carnivoro(Receta receta)
    {
        if (receta.CantidadCalorias() > 200)
            foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
            {
                if (ingrediente.Key.Tipo.Nombre.Equals("carnes"))
                    return true;
            }
        return false;
    }

    bool Celiaco(Receta receta)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Nombre.Equals("cereales"))
                return false;
        }
        return true;
    }

    bool Vegano(Receta receta)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Nombre.Equals("carnes") || ingrediente.Key.Tipo.Nombre.Equals("lacteos"))
                return false;
        }
        return true;
    }

    bool Vegetariano(Receta receta)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Nombre.Equals("carnes"))
                return false;
        }
        return true;
    }
}