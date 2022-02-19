using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Discount.Store.Core.CartAggregate;
using Discount.Store.Infrastructure.ApiEndpoints;
using Discount.Store.SharedKernel.Interfaces;
using Discount.Store.Web.Endpoints.ItemEndpoints;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Annotations;

namespace Discount.Store.Web.Endpoints.CartEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<CartListResponse>
    {
        private readonly IRepository<Cart> repository;

        public List(IRepository<Cart> repository)
        {
            this.repository = repository;
        }

        [HttpGet("/Carts")]
        [SwaggerOperation(
            Summary = "Gets a list of all Carts",
            Description = "Gets a list of all Carts",
            OperationId = "Cart.List",
            Tags = new[] { "CartEndpoints" })
        ]
        public override async Task<ActionResult<CartListResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new CartListResponse();
            response.Carts = await this.repository.All()
                .Select(cart => new CartRecord(cart.Id, cart.CartItems.Select(ci => new ItemRecord(ci.ItemId, ci.Item.Sku, ci.Item.Price))))
                .ToListAsync();

            return Ok(response);
        }
    }
}
