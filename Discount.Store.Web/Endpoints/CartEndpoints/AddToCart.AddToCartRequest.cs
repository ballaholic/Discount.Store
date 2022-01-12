using System.ComponentModel.DataAnnotations;

namespace Discount.Store.Web.Endpoints.CartEndpoints
{
    public class AddToCartRequest
    {
        public const string Route = "/Carts/AddToCart/{CartId:int}/{ItemId:int}";

        public static string BuildRoute(int cartId, int itemId) 
            => Route
                .Replace("{CartId:int}", cartId.ToString())
                .Replace("{ItemId:int}", itemId.ToString());

        [Required]
        public int CartId { get; set; }

        [Required]
        public int ItemId { get; set; }
    }
}
