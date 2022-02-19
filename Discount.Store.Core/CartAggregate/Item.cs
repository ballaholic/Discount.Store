using Discount.Store.SharedKernel;

using System.Collections.Generic;

namespace Discount.Store.Core.CartAggregate
{
    public class Item : BaseEntity
    {
        public string Sku { get; set; }

        public decimal Price { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
