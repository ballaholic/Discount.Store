using Discount.Store.SharedKernel;
using Discount.Store.SharedKernel.Interfaces;

using Discount.Store.Core.ItemAggregate;

using System.Collections.Generic;

namespace Discount.Store.Core.CartAggregate
{
    public class Cart : BaseEntity, IAggregateRoot
    {
        public Cart()
        {
            this.Items = new List<Item>();
        }

        public ICollection<Item> Items { get; set; }
    }
}
