using Gourmet.Repositories.Contracts;
using Gourmet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Services
{
    public class IngredienteRecetaService : GenericService<IngredientesReceta>, IIngredienteRecetaService
    {
        private readonly IIngredienteRecetaRepository _repository;
        public IngredienteRecetaService(IIngredienteRecetaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<IngredientesReceta> GetIngredientesDeReceta(long idReceta)
        {
            return _repository.GetIngredientesDeReceta(idReceta);
        }
    }
}
