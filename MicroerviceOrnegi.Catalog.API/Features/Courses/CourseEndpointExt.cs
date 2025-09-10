using Asp.Versioning.Builder;
using MicroerviceOrnegi.Catalog.API.Features.Courses.Create;
using MicroerviceOrnegi.Catalog.API.Features.Courses.Delete;
using MicroerviceOrnegi.Catalog.API.Features.Courses.GetAll;
using MicroerviceOrnegi.Catalog.API.Features.Courses.GetAllByUserId;
using MicroerviceOrnegi.Catalog.API.Features.Courses.GetById;
using MicroerviceOrnegi.Catalog.API.Features.Courses.Update;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses
{

    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app,ApiVersionSet ap)
        {
            app.MapGroup("api/v{version:apiVersion}/courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCoursesGroupItemEndpoint()
                .GetCourseByIdGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetCourseByUserIdGroupItemEndpoint()
                .WithApiVersionSet(ap)
                .WithTags("Courses");
        }
    }
}
