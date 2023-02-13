using Gourmet;

namespace GourmetApi.Repositories.Contracts
{
    public interface IRecetaRepository
    {
        IEnumerable<Recetario> GetRecetas();
        Recetario GetRecetaByID(int recetarioId);
        void InsertReceta(Recetario recetario);
        void DeleteReceta(int recetarioID);
        void UpdateReceta(Recetario recetario);
        void Save();
    }
}
