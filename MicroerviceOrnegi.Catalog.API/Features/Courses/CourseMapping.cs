namespace MicroerviceOrnegi.Catalog.API.Features.Courses
{
    public class CourseMapping:Profile
    {
        public CourseMapping()
        {
            CreateMap<Create.CreateCourseCommand, Course>().ReverseMap();
        }
    }
}
