using Discount.Store.SharedKernel;
using Discount.Store.SharedKernel.Interfaces;

using System.Collections.Generic;

namespace Discount.Store.Core.CartAggregate
{
    public class Cart : BaseEntity, IAggregateRoot
    {
        public ICollection<CartItem> CartItems { get; set; }
    }
}
