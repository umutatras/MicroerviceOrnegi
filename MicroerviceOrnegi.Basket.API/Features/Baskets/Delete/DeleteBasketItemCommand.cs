using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Delete
{
    public record DeleteBasketItemCommand(Guid CourseId):IRequestByServiceResult
    {
    }
}
