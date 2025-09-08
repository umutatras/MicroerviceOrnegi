using MediatR;
using MicroerviceOrnegi.Catalog.API.Features.Categories.Create;
using MicroerviceOrnegi.Catalog.API.Features.Categories.Dtos;
using MicroerviceOrnegi.Catalog.API.Repositories;
using MicroerviceOrnegi.Shared;
using MicroerviceOrnegi.Shared.Extensions;
using MicroerviceOrnegi.Shared.Filter;
using Microsoft.EntityFrameworkCore;

namespace MicroerviceOrnegi.Catalog.API.Features.Categories.GetAll
{

    public class GetAllCategoryQuery:IRequest<ServiceResult<List<CategoryDto>>>;
    public class GetAllCategoyHandler(AppDbContext context) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
        {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories
                .ToListAsync(cancellationToken);
            var categoryAsDto=categories.Select(x=>new CategoryDto(x.Id,x.Name)).ToList();

            return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoryAsDto);
        }
    }
    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (IMediator mediator) => (await mediator.Send(new GetAllCategoryQuery())).ToGenericResult());

            return group;
        }
    }
}
