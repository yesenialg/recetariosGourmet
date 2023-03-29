using Gourmet.Ingredientes;
using Gourmet.Repositories.Contracts;
using Gourmet.Services.Contracts;

namespace Gourmet.Services
{
    public class IngredienteService : GenericService<Ingrediente>, IIngredienteService
    {
        public IngredienteService(IIngredienteRepository repository) : base(repository){}
    }
}
