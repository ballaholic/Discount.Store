using Discount.Store.Core.CartAggregate;
using Discount.Store.SharedKernel;
using Discount.Store.SharedKernel.Interfaces;


namespace Discount.Store.Core.ItemAggregate
{
    public class Item : BaseEntity, IAggregateRoot
    {
        public string Sku { get; set; }

        public decimal Price { get; set; }
    }
}
