﻿using Asp.Versioning.Builder;

namespace MicroerviceOrnegi.Order.API.Endpoints.Orders
{
    public static class OrderEndpointExt
    {
        public static void AddOrderGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/orders")
                .WithTags("Orders")
                .WithApiVersionSet(apiVersionSet)
                .CreateOrderGroupItemEndpoint()
                .GetOrdersGroupItemEndpoint()
                .RequireAuthorization("Password");
        }
    }
}
