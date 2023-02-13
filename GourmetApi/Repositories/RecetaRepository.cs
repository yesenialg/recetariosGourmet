using Gourmet;
using GourmetApi.Repositories.Contracts;

namespace GourmetApi.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private DBRecetariosContext context;

        public RecetaRepository(DBRecetariosContext context)
        {
            this.context = context;
        }

        public void DeleteReceta(int recetarioID)
        {
            throw new NotImplementedException();
        }

        public Recetario GetRecetaByID(int recetarioId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recetario> GetRecetas()
        {
            throw new NotImplementedException();
        }

        public void InsertReceta(Recetario recetario)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateReceta(Recetario recetario)
        {
            throw new NotImplementedException();
        }
    }
}
