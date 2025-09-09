using MicroerviceOrnegi.Catalog.API.Features.Courses;

namespace MicroerviceOrnegi.Catalog.API.Features.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = default!;
        public List<Course>? Courses { get; set; }
    }
}
