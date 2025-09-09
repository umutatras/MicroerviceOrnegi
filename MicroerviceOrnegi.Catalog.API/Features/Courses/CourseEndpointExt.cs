using MicroerviceOrnegi.Catalog.API.Features.Categories.Create;
using MicroerviceOrnegi.Catalog.API.Features.Courses.Create;
using MicroerviceOrnegi.Catalog.API.Features.Courses.GetAll;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses
{
   
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCoursesGroupItemEndpoint()
                .WithTags("Courses");
        }
    }
}
