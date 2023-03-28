using Gourmet.ContextDB;
using Gourmet.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Gourmet.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DBRecetariosContext _context;

        public GenericRepository(DBRecetariosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetById(long id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(long id)
        {
            var entity = await GetById(id);

            if (entity == null)
            {
                throw new Exception("The entity is null");
            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
