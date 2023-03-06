namespace Gourmet;
using Gourmet.Ingredientes;
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

    public int CantidadIngredientes() => IngredientesReceta.Count;

    public double CantidadCalorias() => IngredientesReceta.Sum(ingrediente => ingrediente.CalcularCalorias());
    public bool PresenciaDeIngrediente(IngredienteCuantitativo ingrediente) => IngredientesReceta.Any(i => i.CompararIngrediente(ingrediente));

    public bool PresenciaDeGrupoAlimenticio(Tipo grupo) => IngredientesReceta.Any(ingrediente => ingrediente.GrupoAlimentario().Equals(grupo));
}