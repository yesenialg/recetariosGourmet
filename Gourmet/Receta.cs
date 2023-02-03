namespace Gourmet;
using Gourmet;
using System.Collections.Generic;

public partial class Receta
{
    public Receta()
    {
        IngredientesReceta = new HashSet<IngredientesReceta>();
        RecetasRecetario = new HashSet<RecetasRecetario>();
    }

    public long Id { get; set; }
    public string? Titulo { get; set; }

    public virtual ICollection<IngredientesReceta> IngredientesReceta { get; set; }
    public virtual ICollection<RecetasRecetario> RecetasRecetario { get; set; }

    public double CantidadCalorias()
    {
        var cantidadCalorias = 0.0;
        foreach (IngredientesReceta ingrediente in IngredientesReceta)
        {
            cantidadCalorias += ingrediente.CalcularCalorias();
        }
        return cantidadCalorias;
    }

    public int CantidadIngredientes()
    {
        return IngredientesReceta.Count;
    }

    public bool PresenciaDeIngrediente(IngredienteCuantitativo ingrediente)
    {
        foreach (IngredientesReceta i in IngredientesReceta)
        {
            if (i.CompararIngrediente(ingrediente))
            {
                return true;
            };
        }
        return false;
    }

    public bool PresenciaDeGrupoAlimenticio(Tipo grupo)
    {
        foreach (IngredientesReceta ingrediente in IngredientesReceta)
        {
            if (ingrediente.GrupoAlimentario().Equals(grupo.Id))
            {
                return true;
            };
        }
        return false;
    }
}