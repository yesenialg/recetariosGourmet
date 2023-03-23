namespace Gourmet.Repositories.Contracts
{
    public interface IRecetasRecetarioRepository : IGenericRepository<RecetasRecetario>
    {
        public IEnumerable<RecetasRecetario> GetRecetasDeRecetario(long idRecetario);
    }
}
