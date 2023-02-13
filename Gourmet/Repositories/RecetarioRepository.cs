using Gourmet;
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

        public void DeleteRecetario(long recetarioID)
        {
            Recetario recetario = context.Recetarios.Find(recetarioID);
            context.Recetarios.Remove(recetario);
        }

        public Recetario GetRecetarioByID(int id)
        {
            return context.Recetarios.Find(id);
        }

        public Recetario GetRecetarioByTitle(string recetarioTitle)
        {
            return context.Recetarios.Where(s => s.Titulo == recetarioTitle).ToList()[0];
        }

        public IEnumerable<Recetario> GetRecetarios()
        {
            return context.Recetarios.ToList();
        }

        public void InsertRecetario(Recetario recetario)
        {
            context.Recetarios.Add(recetario);
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void UpdateRecetario(Recetario recetario)
        {
            context.Entry(recetario).State = EntityState.Modified;
        }

        public List<RecetasUnRecetario> RecetasDeUnRecetario(int id)
        {
            using var context = new DBRecetariosContext();

            var query = (from receta in context.Recetas
                         join recetariorecetas in context.RecetasRecetarios
                         on receta.Id equals recetariorecetas.IdReceta
                         join recetario in context.Recetarios
                         on recetariorecetas.IdRecetario equals recetario.Id
                         where recetariorecetas.IdRecetario == id
                         select new RecetasUnRecetario
                         {
                             IdRecetario = id,
                             Recetario = recetario.Titulo,
                             Receta = receta.Titulo
                         }).ToList();
            return query;
        }
    }
}
