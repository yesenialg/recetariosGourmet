namespace Gourmet.Repositories.Contracts
{
    public interface IIngredienteRecetaRepository
    {
        IEnumerable<IngredientesReceta> GetIngredientesRecetas();
        IEnumerable<IngredientesReceta> GetIngredientesDeReceta(long idReceta);
        IngredientesReceta GetIngredienteRecetaByID(int id);
        void InsertIngredienteReceta(IngredientesReceta ingredienteReceta);
        void DeleteIngredienteReceta(int ingredienteRecetaID);
        void UpdateIngredienteReceta(IngredientesReceta ingredienteReceta);
        int Save();
    }
}
