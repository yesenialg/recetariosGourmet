using Gourmet;

namespace GourmetApi.Repositories.Contracts
{
    public interface IRecetarioRepository
    {
        IEnumerable<Recetario> GetRecetarios();
        Recetario GetRecetarioByID(int recetarioId);
        void InsertRecetario(Recetario recetario);
        void DeleteRecetario(int recetarioID);
        void UpdateRecetario(Recetario recetario);
        List<RecetasUnRecetario> RecetasDeUnRecetario(int id);
        void Save();
    }
}
