
namespace Gourmet.Repositories.Contracts
{
    public interface IRecetaRepository
    {
        IEnumerable<Receta> GetRecetas();
        Receta GetRecetaByID(int recetaId);
        void InsertReceta(Receta receta);
        void DeleteReceta(int recetaID);
        void UpdateReceta(Receta receta);
        void Save();
    }
}
