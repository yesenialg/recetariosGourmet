using Gourmet.Repositories.Contracts;
using Gourmet.Services.Contracts;

namespace Gourmet.Services
{
    public class RecetarioService : GenericService<Recetario>, IRecetarioService
    {
        private readonly IRecetarioRepository _repository;

        public RecetarioService(IRecetarioRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Recetario GetRecetarioByTitle(string recetarioTitle) => _repository.GetRecetarioByTitle(recetarioTitle);

    }
}