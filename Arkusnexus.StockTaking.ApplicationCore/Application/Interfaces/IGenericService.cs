using Arkusnexus.StockTaking.ApplicationCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkusnexus.StockTaking.ApplicationCore.Application.Interfaces
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T Entity);
        void Delete(T entity);
    }
}
