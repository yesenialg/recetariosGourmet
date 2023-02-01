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

    public double CantidadCalorias()
    {
        var cantidadCalorias = 0.0;
        foreach (KeyValuePair<IngredienteCuantitativo, double> ingrediente in Ingredientes)
        {
            cantidadCalorias += ingrediente.Key.CalcularCalorias(ingrediente.Value);
        }
        return cantidadCalorias;
    }

    public int CantidadIngredientes()
    {
        return Ingredientes.Count;
    }

    public bool PresenciaDeIngrediente(IngredienteCuantitativo ingrediente)
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

    public bool PresenciaDeGrupoAlimenticio(Tipo grupo)
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