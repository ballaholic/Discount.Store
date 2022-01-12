using System.Collections.Generic;

namespace Discount.Store.SharedKernel
{
    // This can be modified to BaseEntity<TKey> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}