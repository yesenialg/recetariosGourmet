namespace Gourmet;
using Gourmet;

public class Receta
{
    public string Titulo { get; set; }
    public Dictionary<IngredienteCuantitativo, double> Ingredientes { get; set; }

    public Receta(string titulo, Dictionary<IngredienteCuantitativo, double> ingredientes)
    {
        this.Titulo = titulo;
        this.Ingredientes = ingredientes;
    }

    public double cantidadCalorias()
    {
        var cantidadCalorias = 0.0;
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in Ingredientes)
        {
            cantidadCalorias += ingrediente.Key.calcularCalorias(ingrediente.Value);
        }
        return cantidadCalorias;
    }

    public int cantidadIngredientes()
    {
        return Ingredientes.Count;
    }

    public bool presenciaDeIngrediente(IngredienteCuantitativo ingrediente)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> i in Ingredientes)
        {
            if (i.Key.Nombre.Equals(ingrediente.Nombre))
            {
                return true;
            };
        }
        return false;
    }

    public bool presenciaDeGrupoAlimenticio(Tipo grupo)
    {
        foreach (KeyValuePair<IngredienteCuantitativo, double> i in Ingredientes)
        {
            if (i.Key.Tipo.Equals(grupo))
            {
                return true;
            };
        }
        return false;
    }
}