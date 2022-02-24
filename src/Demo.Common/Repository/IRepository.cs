using System;
using System.Threading.Tasks;

namespace Demo.Common.Repository
{
    public interface IRepository<T> : IReadOnlyRepository<T>  where T : class
    {
        Task CreateAsync(T aggregate);
        Task UpdateAsync(Guid id, T aggregate);
    }
}