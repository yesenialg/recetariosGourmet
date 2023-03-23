using Gourmet.Ingredientes;
using Gourmet.Repositories.Contracts;
using Gourmet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Services
{
    internal class IngredienteService : GenericService<Ingrediente>, IIngredienteService
    {
        private readonly IIngredienteRepository _repository;
        public IngredienteService(IIngredienteRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
