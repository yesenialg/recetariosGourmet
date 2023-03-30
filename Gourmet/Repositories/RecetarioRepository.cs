using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;

namespace Gourmet.Repositories
{
    public class RecetarioRepository : GenericRepository<Recetario>, IRecetarioRepository
    {
        private readonly DBRecetariosContext _context;

        public RecetarioRepository(DBRecetariosContext context) : base (context){}

        public Recetario GetRecetarioByTitle(string recetarioTitle) => _context.Recetarios.Where(s => s.Titulo == recetarioTitle).ToList()[0];
    }
}
