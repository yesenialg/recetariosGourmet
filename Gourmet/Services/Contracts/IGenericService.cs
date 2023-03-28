namespace Gourmet.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task<T> Add(T entity);
        Task Delete(long id);
        Task<T> Update(T entity);
    }
}
