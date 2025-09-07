using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MicroerviceOrnegi.Catalog.API.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateCategoryCommand Command, IMediator mediator) =>
            {
                var result = await mediator.Send(Command);
                return new ObjectResult(result)
                {
                    StatusCode = result.Status.GetHashCode()
                };
            });

            return group;
        }
    }
}
