namespace Gourmet.Repositories.Contracts
{
    public interface IRecetarioRepository
    {
        IEnumerable<Recetario> GetRecetarios();
        Recetario GetRecetarioByID(int recetarioId);
        Recetario GetRecetarioByTitle(string recetarioTitle);
        void InsertRecetario(Recetario recetario);
        void DeleteRecetario(long recetarioID);
        void UpdateRecetario(Recetario recetario);
        int Save();
    }
}
