using Gourmet.Repositories.Contracts;
using Gourmet.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Services
{
    public class RecetaService : GenericService<Receta>, IRecetaService
    {
        private readonly IRecetaRepository _repository;
        public RecetaService(IRecetaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
