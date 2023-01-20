namespace Gourmet;
using Gourmet;

public class Perfil
{
    public string Nombre { get; set; }

    public Perfil(string nombre)
    {
        this.Nombre = nombre;
    }

    public bool recetaApta(Receta receta)
    {
        if (this.Nombre == "carnivoro")
        {
            return this.carnivoro(receta);
        }
        else if (this.Nombre == "celiaco")
        {
            return this.celiaco(receta);
        }
        else if (this.Nombre == "vegano")
        {
            return this.vegano(receta);
        }
        else if (this.Nombre == "vegetariano")
        {
            return this.vegetariano(receta);
        }
        else
        {
            return true;
        }
    }

    bool carnivoro(Receta receta)
    {
        if (receta.cantidadCalorias() > 200)
            foreach (KeyValuePair<Ingrediente, double> ingrediente in receta.Ingredientes)
            {
                if (ingrediente.Key.Tipo.Equals("carnes"))
                    return true;
            }
        return false;
    }

    bool celiaco(Receta receta)
    {
        foreach (KeyValuePair<Ingrediente, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Equals("cereales"))
                return false;
        }
        return true;
    }

    bool vegano(Receta receta)
    {
        foreach (KeyValuePair<Ingrediente, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Equals("carnes") || ingrediente.Key.Tipo.Equals("lacteos"))
                return false;
        }
        return true;
    }

    bool vegetariano(Receta receta)
    {
        foreach (KeyValuePair<Ingrediente, double> ingrediente in receta.Ingredientes)
        {
            if (ingrediente.Key.Tipo.Equals("carnes"))
                return false;
        }
        return true;
    }
}