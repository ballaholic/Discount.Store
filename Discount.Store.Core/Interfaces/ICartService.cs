using Discount.Store.Core.CartAggregate;

using System.Threading.Tasks;

namespace Discount.Store.Core.Interfaces
{
    public interface ICartService
    {
        Task<Cart> AddItemToCart(int cartId, int itemId);
    }
}
