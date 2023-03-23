namespace Gourmet;

using Gourmet.ContextDB;
using Gourmet.Ingredientes;
using Gourmet.Repositories;
using Gourmet.Services;
using Gourmet.Services.Contracts;

public partial class IngredientesReceta
{
    private readonly IIngredienteService _ingredienteService = new IngredienteService(new IngredienteRepository(new DBRecetariosContext()));
    public long Id { get; set; }
    public long IdIngrediente { get; set; }
    public double CantidadIngrediente { get; set; }
    public long IdReceta { get; set; }

    public virtual IngredienteCuantitativo? IdIngredienteNavigation { get; set; }
    public virtual Receta? IdRecetaNavigation { get; set; }

    public double CalcularCalorias()
    {
        Ingrediente ingrediente = _ingredienteService.GetById(IdIngrediente).Result;
        return ingrediente .CalcularCalorias(CantidadIngrediente);
    }

    public async Task<bool> CompararIngrediente(IngredienteCuantitativo ingrediente) => (await _ingredienteService.GetById(IdIngrediente)).Nombre.Equals(ingrediente.Nombre);

    public async Task<Tipo> GrupoAlimentario()
    {
        return (await _ingredienteService.GetById(IdIngrediente)).Tipo;
    }
}