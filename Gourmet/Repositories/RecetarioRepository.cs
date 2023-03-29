using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;

namespace Gourmet.Repositories
{
    public class RecetarioRepository : GenericRepository<Recetario>, IRecetarioRepository
    {
        private readonly DBRecetariosContext _context;

        public RecetarioRepository(DBRecetariosContext context) : base(context) { 
            _context = context;
        }

        public Recetario GetRecetarioByTitle(string recetarioTitle) => _context.Recetarios.Where(s => s.Titulo == recetarioTitle).ToList()[0];

        public List<ICollection<Receta>> RecetasDeUnRecetario(long id) => _context.Recetarios.Where(s => s.Id == id).Select(s => s.Recetas).ToList();

    }
}
