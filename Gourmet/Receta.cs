namespace Gourmet;
using Gourmet;

public class Receta
{
    public string Titulo { get; set; }
    public Dictionary<Ingrediente, double> Ingredientes { get; set; }

    public Receta(string titulo, Dictionary<Ingrediente, double> ingredientes)
    {
        this.Titulo = titulo;
        this.Ingredientes = ingredientes;
    }

    public double cantidadCalorias()
    {
        var cantidadCalorias = 0.0;
        foreach (KeyValuePair<Ingrediente, double> ingrediente in Ingredientes)
        {
            cantidadCalorias += ingrediente.Key.Caloriasporunidad * ingrediente.Value;
        }
        return cantidadCalorias;
    }

    public int cantidadIngredientes()
    {
        return Ingredientes.Count;
    }

    public bool presenciaDeIngrediente(Ingrediente ingrediente)
    {
        foreach (KeyValuePair<Ingrediente, double> i in Ingredientes)
        {
            if (i.Key.Nombre.Equals(ingrediente.Nombre))
            {
                return true;
            };
        }
        return false;
    }

    public bool presenciaDeGrupoAlimenticio(string grupo)
    {
        foreach (KeyValuePair<Ingrediente, double> i in Ingredientes)
        {
            if (i.Key.Tipo.Equals(grupo))
            {
                return true;
            };
        }
        return false;
    }
}