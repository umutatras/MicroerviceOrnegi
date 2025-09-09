namespace MicroerviceOrnegi.Catalog.API.Features.Categories.Create
{
    public record CreateCategoryCommand(string name) : IRequestByServiceResult<CreateCategoryResponse>;

}
