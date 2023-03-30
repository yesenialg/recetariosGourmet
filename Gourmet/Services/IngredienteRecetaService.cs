using Gourmet.Repositories.Contracts;
using Gourmet.Services.Contracts;

namespace Gourmet.Services
{
    public class IngredienteRecetaService : GenericService<IngredientesReceta>, IIngredienteRecetaService
    {
        private readonly IIngredienteRecetaRepository _repository;

        public IngredienteRecetaService(IIngredienteRecetaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<IngredientesReceta> GetIngredientesDeReceta(long idReceta) => _repository.GetIngredientesDeReceta(idReceta);
    }
}
