using MicroerviceOrnegi.Basket.API.Dtos;
using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.GetBasket
{
    public record GetBasketQuery:IRequestByServiceResult<BasketDto>
    {
    }
}
