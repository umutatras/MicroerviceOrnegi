namespace MicroerviceOrnegi.Catalog.API.Features.Categories.GetById
{

    public record GetByIdCategoryQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;

    public class GetByIdCategoyHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetByIdCategoryQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.FindAsync(request.Id, cancellationToken);
            if (hasCategory == null)
                return ServiceResult<CategoryDto>.Error("Category Not Found", "The category with in id ...", System.Net.HttpStatusCode.NotFound);


            var categoryAsDto = mapper.Map<CategoryDto>(hasCategory);

            return ServiceResult<CategoryDto>.SuccessAsOk(categoryAsDto);
        }
    }
    public static class GetByIdCategoryEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) => (await mediator.Send(new GetByIdCategoryQuery(id))).ToGenericResult());

            return group;
        }
    }
}
