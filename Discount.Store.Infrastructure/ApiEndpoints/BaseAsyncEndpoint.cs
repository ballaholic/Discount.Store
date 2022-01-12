using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Discount.Store.Infrastructure.ApiEndpoints
{
    public static class BaseAsyncEndpoint
    {
        public static class WithRequest<TRequest>
        {
            public abstract class WithResponse<TResponse> : BaseEndpointAsync
            {
                protected WithResponse() { }

                public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
            }

            public abstract class WithoutResponse : BaseEndpointAsync
            {
                protected WithoutResponse() { }

                public abstract Task<ActionResult> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
            }
        }

        public static class WithoutRequest
        {
            public abstract class WithResponse<TResponse> : BaseEndpointAsync
            {
                protected WithResponse() { }

                public abstract Task<ActionResult<TResponse>> HandleAsync(CancellationToken cancellationToken = default);
            }
            public abstract class WithoutResponse : BaseEndpointAsync
            {
                protected WithoutResponse() { }

                public abstract Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default);
            }
        }
    }
}
