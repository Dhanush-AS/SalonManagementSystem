using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Application.Persistance.Contracts
{
    public interface IGenricRepo<T> where T : class
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>AddAsync(T item);
        Task UpdateAsync(T item, string id);
        Task DeleteAsync( string id);
        Task<T> QuerySingleOrDefaultAsync(Func<IQueryable<T>, IQueryable<T>> query);

    }
}
