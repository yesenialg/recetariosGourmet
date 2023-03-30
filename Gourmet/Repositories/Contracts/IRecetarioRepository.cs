namespace Gourmet.Repositories.Contracts
{
    public interface IRecetarioRepository : IGenericRepository<Recetario>
    {
        Recetario GetRecetarioByTitle(string recetarioTitle);
    }
}
