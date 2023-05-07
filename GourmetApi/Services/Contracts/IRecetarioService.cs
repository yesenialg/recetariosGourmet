namespace Gourmet.Services.Contracts
{
    public interface IRecetarioService : IGenericService<Recetario>
    {
        Recetario GetRecetarioByTitle(string recetarioTitle);

    }
}
