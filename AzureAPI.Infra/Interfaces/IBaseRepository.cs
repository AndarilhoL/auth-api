using AzureAPI.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureAPI.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task<T> GetById(long id);
        Task<List<T>> GetAll();
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Remove(long id);
        
    }
}
