using Discount.Store.Web.Endpoints.ItemEndpoints;

using System.Collections.Generic;

namespace Discount.Store.Web.Endpoints.CartEndpoints
{
    public record CartRecord(int Id, IEnumerable<ItemRecord> Items);
}
