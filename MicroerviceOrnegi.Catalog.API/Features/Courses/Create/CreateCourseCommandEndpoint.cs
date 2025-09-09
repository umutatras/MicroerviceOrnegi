using MicroerviceOrnegi.Catalog.API.Features.Categories.Create;
using MicroerviceOrnegi.Shared.Filter;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses.Create
{
  
    public static class CreateCourseCommandEndpoint
    {
        public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/", async (CreateCourseCommand Command, IMediator mediator) => (await mediator.Send(Command)).ToGenericResult()).AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();

            return group;
        }
    }
}
