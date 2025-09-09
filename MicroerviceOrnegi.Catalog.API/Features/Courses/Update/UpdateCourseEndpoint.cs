using MicroerviceOrnegi.Shared.Filter;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses.Update
{

    public static class UpdateCourseEndpoint
    {
        public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPut("/", async (UpdateCourseCommand Command, IMediator mediator) => (await mediator.Send(Command)).ToGenericResult()).AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>();

            return group;
        }
    }
}
