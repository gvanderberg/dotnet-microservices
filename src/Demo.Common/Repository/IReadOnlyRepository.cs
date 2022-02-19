using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Common.Repository
{
    public interface IReadOnlyRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
    }
}