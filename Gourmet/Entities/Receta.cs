namespace Gourmet;

using Gourmet.ContextDB;
using Gourmet.Ingredientes;
using Gourmet.Repositories;
using Gourmet.Services;
using Gourmet.Services.Contracts;
using System.Collections.Generic;

public partial class Receta
{
    private readonly IIngredienteRecetaService _ingredienteRecetaService = new IngredienteRecetaService(new IngredienteRecetaRepository(new DBRecetariosContext()));
    public Receta()
    {
        IngredientesReceta = new HashSet<IngredientesReceta>();
        RecetasRecetario = new HashSet<RecetasRecetario>();
    }

    public long Id { get; set; }
    public string? Titulo { get; set; }

    public virtual ICollection<IngredientesReceta> IngredientesReceta { get; set; }
    public virtual ICollection<RecetasRecetario> RecetasRecetario { get; set; }

    public int CantidadIngredientes()
    {
        var ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(Id);
        return ingredientes.Count();
    }

    public double CantidadCalorias()
    {
        var ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(Id);
        return ingredientes.Sum(ingrediente => ingrediente.CalcularCalorias());
    }

    public bool PresenciaDeIngrediente(IngredienteCuantitativo ingrediente)
    {
        var ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(Id).ToList();
        return ingredientes.Any(i => i.CompararIngrediente(ingrediente).Result);
    }

    public bool PresenciaDeGrupoAlimenticio(Tipo grupo)
    {
        var ingredientes = _ingredienteRecetaService.GetIngredientesDeReceta(Id).ToList();
        return ingredientes.Any(ingrediente => ingrediente.GrupoAlimentario().Result.Equals(grupo));
    }
}