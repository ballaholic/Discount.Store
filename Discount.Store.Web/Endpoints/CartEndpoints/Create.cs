using System.Threading;
using System.Threading.Tasks;

using Discount.Store.Core.CartAggregate;
using Discount.Store.Infrastructure.ApiEndpoints;
using Discount.Store.SharedKernel.Interfaces;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace Discount.Store.Web.Endpoints.CartEndpoints
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateCartRequest>
        .WithResponse<CreateCartResponse>
    {
        private readonly IRepository<Cart> repository;

        public Create(IRepository<Cart> repository)
        {
            this.repository = repository;
        }

        [HttpPost("/Carts")]
        [SwaggerOperation(
            Summary = "Creates a new Cart",
            Description = "Creates a new Cart",
            OperationId = "Cart.Create",
            Tags = new[] { "CartEndpoints" })
        ]
        public override async Task<ActionResult<CreateCartResponse>> HandleAsync(CreateCartRequest request,
            CancellationToken cancellationToken)
        {
            var newCart = new Cart();

            var createdItem = await repository.AddAsync(newCart, cancellationToken);

            var response = new CreateCartResponse
            {
                Id = createdItem.Id
            };

            return Ok(response);
        }
    }
}
