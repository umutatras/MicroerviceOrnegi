using MicroerviceOrnegi.Catalog.API.Features.Courses.Dtos;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses.GetById
{
    public record class GetCourseByIdQuery(Guid Id) : IRequestByServiceResult<CourseDto>;

    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDto>>
    {
        public async Task<ServiceResult<CourseDto>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (course == null)
            {
                return ServiceResult<CourseDto>.Error("Course not found", "", HttpStatusCode.NotFound);
            }
            course.Category = await context.Categories.FirstAsync(x => x.Id == course.CategoryId, cancellationToken);
            var courseAsDto = mapper.Map<CourseDto>(course);
            return ServiceResult<CourseDto>.SuccessAsOk(courseAsDto);
        }
    }

    public static class GetCourseByIdEndpoint
    {
        public static RouteGroupBuilder GetCourseByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) => (await mediator.Send(new GetCourseByIdQuery(id))).ToGenericResult());

            return group;
        }
    }
}
