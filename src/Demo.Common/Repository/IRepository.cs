using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Common.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T>  where T : class
    {
        Task CreateAsync(T aggregate);
        Task UpdateAsync(long id, T aggregate);
    }
}