using Discount.Store.SharedKernel;
using Discount.Store.Core.CartAggregate;
using Discount.Store.SharedKernel.Interfaces;

using System.Collections.Generic;

namespace Discount.Store.Core.ItemAggregate
{
    public class Item : BaseEntity, IAggregateRoot
    {
        public string Sku { get; set; }

        public decimal Price { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
