using Discount.Store.Core.Interfaces;
using Discount.Store.Infrastructure.ApiEndpoints;
using Discount.Store.Web.Endpoints.ItemEndpoints;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Discount.Store.Web.Endpoints.CartEndpoints
{
    public class AddToCart : BaseAsyncEndpoint
        .WithRequest<AddToCartRequest>
        .WithResponse<AddToCartResponse>
    {
        private readonly ICartService cartService;


        public AddToCart(ICartService cartService)
        {
            this.cartService = cartService;
        }


        [HttpPost(AddToCartRequest.Route)]
        [SwaggerOperation(
            Summary = "Adds an item to a cart",
            Description = "Adds an item to a cart",
            OperationId = "Cart.AddToCart",
            Tags = new[] { "CartEndpoints" })
        ]
        public override async Task<ActionResult<AddToCartResponse>> HandleAsync([FromRoute] AddToCartRequest request, CancellationToken cancellationToken = default)
        {
            var updatedCart = await this.cartService.AddItemToCart(request.CartId, request.ItemId);

            var response = new AddToCartResponse
            {
                Cart = new CartRecord(
                    updatedCart.Id, 
                    updatedCart.CartItems.Select(cartItem => new ItemRecord(cartItem.ItemId, cartItem.Item.Sku, cartItem.Item.Price)).ToList())
            };

            return Ok(response);
        }
    }
}
