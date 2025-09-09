using MicroerviceOrnegi.Catalog.API.Features.Courses.Dtos;

namespace MicroerviceOrnegi.Catalog.API.Features.Courses
{
    public class CourseMapping:Profile
    {
        public CourseMapping()
        {
            CreateMap<Create.CreateCourseCommand, Course>().ReverseMap();
            CreateMap<Course,CourseDto>().ReverseMap();
            CreateMap<Feature,FeatureDto>().ReverseMap();
        }
    }
}
