using Gourmet.Repositories.Contracts;
using Gourmet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Services
{
    public class RecetasRecetarioService : GenericService<RecetasRecetario>, IRecetasRecetarioService
    {
        private readonly IRecetasRecetarioRepository _repository;
        public RecetasRecetarioService(IRecetasRecetarioRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<RecetasRecetario> GetRecetasDeRecetario(long idRecetario)
        {
            return _repository.GetRecetasDeRecetario(idRecetario);
        }
    }
}
