using System;
using System.Threading;
using System.Threading.Tasks;

namespace Discount.Store.SharedKernel.Interfaces
{
    public interface IJunctionEntityRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
