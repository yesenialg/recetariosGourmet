namespace Gourmet;
using Gourmet.Ingredientes;
using System.Collections.Generic;

public partial class Receta
{
    public Receta()
    {
        Recetarios = new HashSet<Recetario>();
        Ingredientes = new HashSet<Ingrediente>();
        IngredientesReceta = new List<IngredientesReceta>();
    }

    public long Id { get; set; }
    public string? Titulo { get; set; }

    public virtual List<IngredientesReceta> IngredientesReceta { get; set; }
    public virtual ICollection<Ingrediente> Ingredientes { get; set; }

    public virtual ICollection<Recetario> Recetarios { get; set; }

    public double CantidadCalorias() => IngredientesReceta.Sum(ingrediente => ingrediente.CalcularCalorias());


}