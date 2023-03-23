using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Repositories
{
    public class RecetasRecetarioRepository : GenericRepository<RecetasRecetario>, IRecetasRecetarioRepository
    {
        private readonly DBRecetariosContext _context;

        public RecetasRecetarioRepository(DBRecetariosContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<RecetasRecetario> GetRecetasDeRecetario(long idRecetario) => _context.RecetasRecetarios.Where(s => s.IdRecetario == idRecetario);
    }
}
