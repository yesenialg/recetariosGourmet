using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Services.Contracts
{
    public interface IIngredienteRecetaService : IGenericService<IngredientesReceta>
    {
        IEnumerable<IngredientesReceta> GetIngredientesDeReceta(long idReceta);
    }
}
