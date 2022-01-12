using System.Collections.Generic;

namespace Discount.Store.Web.Endpoints.CartEndpoints
{
    public class CartListResponse
    {
        public List<CartRecord> Carts { get; set; } = new();
    }
}
