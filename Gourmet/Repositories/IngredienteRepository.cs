using Gourmet.ContextDB;
using Gourmet.Ingredientes;
using Gourmet.Repositories.Contracts;

namespace Gourmet.Repositories
{
    public class IngredienteRepository : GenericRepository<Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(DBRecetariosContext context) : base(context) { }
    }
}