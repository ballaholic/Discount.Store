using Discount.Store.Core.CartAggregate;

using System.ComponentModel.DataAnnotations;

namespace Discount.Store.Core.CartAggregate
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }

        public Cart Cart { get; set; }

        [Key]
        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}
