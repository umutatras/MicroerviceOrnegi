using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Create
{
    public record AddBasketItemCommand(Guid CourseId,string CourseName,decimal CoursePrice,string? ImageUrl):IRequestByServiceResult;
   
}
