using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Discount.Store.SharedKernel.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity, IAggregateRoot
    {
        Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default);

        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
