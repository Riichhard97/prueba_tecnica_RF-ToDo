using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Persistence.Contracts
{
    public interface IBaseRepository<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<T> Update(int id, T entity);
        Task Delete(int id);
    }
}
