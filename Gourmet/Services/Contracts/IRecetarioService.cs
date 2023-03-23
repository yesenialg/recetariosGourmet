using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Services.Contracts
{
    public interface IRecetarioService : IGenericService<Recetario>
    {
        Recetario GetRecetarioByTitle(string recetarioTitle);
    }
}
