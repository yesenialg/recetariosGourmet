using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private DBRecetariosContext context;

        public RecetaRepository(DBRecetariosContext context)
        {
            this.context = context;
        }

        public void DeleteReceta(int recetaID) => context.Recetas.Remove(context.Recetas.Find(recetaID));

        public Receta GetRecetaByID(long recetaId) => context.Recetas.Find(recetaId);

        public IEnumerable<Receta> GetRecetas() => context.Recetas.ToList();

        public void InsertReceta(Receta receta) => context.Recetas.Add(receta);

        public void Save() => context.SaveChanges();

        public void UpdateReceta(Receta receta) => context.Entry(receta).State = EntityState.Modified;
    }
}
