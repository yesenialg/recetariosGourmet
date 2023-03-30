using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;

namespace Gourmet.Repositories
{
    public class IngredienteRecetaRepository : GenericRepository<IngredientesReceta>, IIngredienteRecetaRepository
    {
        private readonly DBRecetariosContext _context;

        public IngredienteRecetaRepository(DBRecetariosContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<IngredientesReceta> GetIngredientesDeReceta(long idReceta) => _context.IngredientesReceta.Where(s => s.RecetaId == idReceta);
    }
}
