namespace Gourmet.Services.Contracts
{
    public interface IIngredienteRecetaService : IGenericService<IngredientesReceta>
    {
        IEnumerable<IngredientesReceta> GetIngredientesDeReceta(long idReceta);
    }
}
