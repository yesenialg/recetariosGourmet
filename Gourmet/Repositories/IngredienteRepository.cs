using Gourmet.ContextDB;
using Gourmet.Ingredientes;
using Gourmet.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Repositories
{
    internal class IngredienteRepository : GenericRepository<Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(DBRecetariosContext context) : base(context) { }
    }
}