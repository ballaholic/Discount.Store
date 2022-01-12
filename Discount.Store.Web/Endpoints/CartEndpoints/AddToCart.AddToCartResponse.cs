using Discount.Store.Web.Endpoints.ItemEndpoints;

using System.Collections.Generic;

namespace Discount.Store.Web.Endpoints.CartEndpoints
{
    public class AddToCartResponse
    {
        public CartRecord Cart { get; set; }

        public List<ItemRecord> Items { get; set; } = new List<ItemRecord>();
    }
}
