using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gourmet.Repositories
{
    public class IngredienteRecetaRepository : IIngredienteRecetaRepository
    {
        private DBRecetariosContext context;

        public IngredienteRecetaRepository(DBRecetariosContext context)
        {
            this.context = context;
        }

        public void DeleteIngredienteReceta(int ingredienteRecetaID) => context.IngredientesReceta.Remove(context.IngredientesReceta.Find(ingredienteRecetaID));

        public IngredientesReceta GetIngredienteRecetaByID(int id) => context.IngredientesReceta.Find(id);

        public IEnumerable<IngredientesReceta> GetIngredientesDeReceta(long idReceta) => context.IngredientesReceta.Where(s => s.IdReceta == idReceta);

        public IEnumerable<IngredientesReceta> GetIngredientesRecetas() => context.IngredientesReceta.ToList();

        public void InsertIngredienteReceta(IngredientesReceta ingredienteReceta) => context.IngredientesReceta.Add(ingredienteReceta);

        public int Save() => context.SaveChanges();

        public void UpdateIngredienteReceta(IngredientesReceta ingredienteReceta) => context.Entry(ingredienteReceta).State = EntityState.Modified;
    }
}
