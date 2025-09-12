using System.Text.Json.Serialization;

namespace MicroerviceOrnegi.Basket.API.Dtos
{
    public record BasketDto
    {
        public List<BasketItemDto> BasketItems { get; set; } = new();
        public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }
        [JsonIgnore] public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
        public decimal TotalPrice => BasketItems.Sum(x => x.Price);

        public decimal? TotalPriceWithAppliedDiscount
        {
            get
            {
                if (!IsApplyDiscount)
                {
                    return null;
                }
                return BasketItems.Sum(x => x.PriceByApplyDiscountRate);
            }
        }
        public BasketDto(List<BasketItemDto> basketItem)
        {
            BasketItems = basketItem;
        }
        public BasketDto()
        {

        }

    }

}
