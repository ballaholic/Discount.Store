using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Discount.Store.Core.ItemAggregate;
using Discount.Store.Infrastructure.ApiEndpoints;
using Discount.Store.SharedKernel.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Annotations;

namespace Discount.Store.Web.Endpoints.ItemEndpoints
{
    public class ListItems : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ItemsListResponse>
    {
        private readonly IRepository<Item> repository;

        public ListItems(IRepository<Item> repository)
        {
            this.repository = repository;
        }

        [HttpGet("/Items")]
        [SwaggerOperation(
            Summary = "Gets a list of all items",
            Description = "Gets a list of all items",
            OperationId = "Item.List",
            Tags = new[] { "ItemEndpoints" })
        ]
        public override async Task<ActionResult<ItemsListResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ItemsListResponse();
            response.Items = await this.repository.All()
                .Select(item => new ItemRecord(item.Id, item.Sku, item.Price))
                .ToListAsync();

            return Ok(response);
        }
    }
}
