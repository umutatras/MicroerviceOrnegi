using MicroerviceOrnegi.Catalog.API.Features.Courses.Create;
using MicroerviceOrnegi.Catalog.API.Features.Courses.GetAll;
using MicroerviceOrnegi.Catalog.API.Features.Courses.GetById;
using MicroerviceOrnegi.Catalog.API.Features.Courses.Update;

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
                .UpdateCourseGroupItemEndpoint()
                .WithTags("Courses");
        }
    }
}
