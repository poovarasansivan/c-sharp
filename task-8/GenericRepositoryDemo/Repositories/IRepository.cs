using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> DeleteAsync(string rollno);
        Task<T?> GetByRollnoAsync(string rollno);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
