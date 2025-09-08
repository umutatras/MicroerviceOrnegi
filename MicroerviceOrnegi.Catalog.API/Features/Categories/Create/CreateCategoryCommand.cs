using MediatR;
using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Catalog.API.Features.Categories.Create
{
    public record CreateCategoryCommand(string name) : IRequestByServiceResult<CreateCategoryCommand>;

}
