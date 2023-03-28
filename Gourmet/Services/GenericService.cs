using Gourmet.Repositories.Contracts;

namespace Gourmet.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Add(T entity) => await _repository.Add(entity);

        public async Task Delete(long id) => await _repository.Delete(id);

        public async Task<IEnumerable<T>> GetAll() => await _repository.GetAll();

        public async Task<T> GetById(long id) => await _repository.GetById(id);

        public async Task<T> Update(T entity) => await _repository.Update(entity);
    }
}
