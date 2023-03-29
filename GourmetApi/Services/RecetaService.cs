using Gourmet.Repositories.Contracts;
using Gourmet.Services.Contracts;

namespace Gourmet.Services
{
    public class RecetaService : GenericService<Receta>, IRecetaService
    {
        public RecetaService(IRecetaRepository repository) : base(repository){}
    }
}
