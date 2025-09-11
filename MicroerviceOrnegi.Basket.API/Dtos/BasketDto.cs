using System.Text.Json.Serialization;

namespace MicroerviceOrnegi.Basket.API.Dtos
{
    public record BasketDto
    {
        [JsonIgnore] public Guid UserId { get; init; }
        public List<BasketItemDto> BasketItems { get; set; } = new();
        public BasketDto(Guid userId, List<BasketItemDto> basketItem)
        {
            UserId = userId;
            BasketItems = basketItem;
        }
        public BasketDto()
        {

        }

    }

}
