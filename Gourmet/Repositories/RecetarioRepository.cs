using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.Repositories
{
    public class RecetarioRepository : IRecetarioRepository
    {
        private DBRecetariosContext context;

        public RecetarioRepository(DBRecetariosContext context)
        {
            this.context = context;
        }

        public void DeleteRecetario(long recetarioID) => context.Recetarios.Remove(context.Recetarios.Find(recetarioID));

        public Recetario GetRecetarioByID(int id) => context.Recetarios.Find(id);

        public Recetario GetRecetarioByTitle(string recetarioTitle) => context.Recetarios.Where(s => s.Titulo == recetarioTitle).ToList()[0];

        public IEnumerable<Recetario> GetRecetarios() => context.Recetarios.ToList();

        public void InsertRecetario(Recetario recetario) => context.Recetarios.Add(recetario);

        public int Save() => context.SaveChanges();

        public void UpdateRecetario(Recetario recetario) => context.Entry(recetario).State = EntityState.Modified;
    }
}
