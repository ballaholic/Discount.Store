using Discount.Store.SharedKernel.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Discount.Store.Infrastructure.Data
{
    public class JuntionEntityRepository<TEntity> : IJunctionEntityRepository<TEntity> where TEntity : class
    {
        public JuntionEntityRepository(AppDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected AppDbContext Context { get; set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.DbSet.Add(entity);

            await this.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            this.DbSet.Remove(entity);

            await this.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await this.Context.SaveChangesAsync(cancellationToken);
        }
    }
}
