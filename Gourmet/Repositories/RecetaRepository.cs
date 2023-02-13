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

        public void DeleteReceta(int recetaID)
        {
            Receta receta = context.Recetas.Find(recetaID);
            context.Recetas.Remove(receta);
        }

        public Receta GetRecetaByID(long recetaId)
        {
            return context.Recetas.Find(recetaId);
        }

        public IEnumerable<Receta> GetRecetas()
        {
            return context.Recetas.ToList();
        }

        public void InsertReceta(Receta receta)
        {
            context.Recetas.Add(receta);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateReceta(Receta receta)
        {
            context.Entry(receta).State = EntityState.Modified;
        }
    }
}
