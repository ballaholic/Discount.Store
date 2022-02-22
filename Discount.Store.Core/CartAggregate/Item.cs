using Discount.Store.SharedKernel;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discount.Store.Core.CartAggregate
{
    public class Item : BaseEntity
    {
        public string Sku { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
