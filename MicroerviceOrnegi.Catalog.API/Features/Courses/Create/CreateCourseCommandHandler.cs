
using MassTransit;
using MicroerviceOrnegi.Bus.Commands;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses.Create
{
    public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper, IPublishEndpoint publishEndpoint) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.AnyAsync(c => c.Id == request.CategoryId, cancellationToken);
            if (!hasCategory)
            {
                return ServiceResult<Guid>.Error("CAtegory not found", "", HttpStatusCode.NotFound);
            }

            var hasCoure = await context.Courses.AnyAsync(c => c.Name == request.Name, cancellationToken);
            if (hasCoure)
            {
                return ServiceResult<Guid>.Error("Course name already exists", "", HttpStatusCode.Conflict);
            }
            var newCourse = mapper.Map<Course>(request);
            newCourse.Created = DateTime.UtcNow;
            newCourse.Id = Guid.NewGuid();
            newCourse.Feature = new Feature()
            {
                Duration = 0,
                Rating = 0,
                EducatorFullName = "ddd"
            };
            await context.Courses.AddAsync(newCourse, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            if (request.Picture is not null)
            {
                using var memoryStream = new MemoryStream();
                await request.Picture.CopyToAsync(memoryStream, cancellationToken);
                var pictureAsByteArray = memoryStream.ToArray();
                UploadCoursePictureCommand uploadCoursePictureCommand = new(newCourse.Id, pictureAsByteArray, request.Picture.FileName);
                await publishEndpoint.Publish(uploadCoursePictureCommand, cancellationToken);


            }
            return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");
        }

    }
}
