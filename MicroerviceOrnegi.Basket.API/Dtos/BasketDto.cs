namespace MicroerviceOrnegi.Basket.API.Dtos
{
    public record BasketDto(Guid UserId,List<BasketItemDto> BasketItems);
    
}
