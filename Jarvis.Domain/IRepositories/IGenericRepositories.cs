using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.Domain.IRepositories
{
    public interface IGenericRepositories<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T t);
        Task Update(T t);
        Task Delete(T t);
        Task<bool> Exist(Expression<Func<T, bool>> function);
    }
}
