namespace Gourmet.Repositories.Contracts
{
    public interface IIngredienteRecetaRepository : IGenericRepository<IngredientesReceta>
    {
        IEnumerable<IngredientesReceta> GetIngredientesDeReceta(long idReceta);
    }
}
