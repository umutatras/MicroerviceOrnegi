namespace MicroerviceOrnegi.Catalog.API.Features.Courses.Dtos
{
    public record CourseDto(Guid Id, string Name, string Description, decimal Price, string ImageUrl, CategoryDto category, FeatureDto feature)
    {
    }
}
