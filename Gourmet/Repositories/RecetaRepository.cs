using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;

namespace Gourmet.Repositories
{
    public class RecetaRepository : GenericRepository<Receta>, IRecetaRepository
    {
        public RecetaRepository(DBRecetariosContext context) : base(context){}
    }
}
