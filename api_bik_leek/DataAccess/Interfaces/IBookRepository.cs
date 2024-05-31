using api_bik_leek.Models;

namespace api_bik_leek.DataAccess.Interfaces
{
    public interface IBookRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int Id);
        Task<T> Insert(T entity);
        Task<T> Delete(int id);
        Task Update(T entity);
        //void Save();
    }
}
