using MicroerviceOrnegi.Catalog.API.Features.Courses.Create;
using MicroerviceOrnegi.Catalog.API.Features.Courses.GetAll;
using MicroerviceOrnegi.Catalog.API.Features.Courses.GetById;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses
{

    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCoursesGroupItemEndpoint()
                .GetCourseByIdGroupItemEndpoint()
                .WithTags("Courses");
        }
    }
}
