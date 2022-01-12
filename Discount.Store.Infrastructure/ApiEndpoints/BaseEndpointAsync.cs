using Microsoft.AspNetCore.Mvc;

namespace Discount.Store.Infrastructure.ApiEndpoints
{
    [ApiController]
    public abstract class BaseEndpointAsync : ControllerBase
    {
        protected BaseEndpointAsync()
        {

        }
    }
}
