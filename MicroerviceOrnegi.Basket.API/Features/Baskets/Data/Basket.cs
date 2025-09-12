using System.Text.Json.Serialization;

namespace MicroerviceOrnegi.Basket.API.Features.Baskets.Data
{
    public class Basket
    {
        public Guid UserId { get; set; }
        public List<BasketItem> Items { get; set; } = new();
        public float? DiscountRate { get; set; }
        public string? Coupon { get; set; }
        [JsonIgnore] public bool IsApplyDiscount => DiscountRate is > 0 && !string.IsNullOrEmpty(Coupon);
        [JsonIgnore] public decimal TotalPrice => Items.Sum(x => x.Price);

        public Basket()
        {

        }
        public Basket(Guid userId, List<BasketItem> items)
        {
            UserId = userId;
            Items = items;
        }
        [JsonIgnore]
        public decimal? TotalPriceWithAppliedDiscount
        {
            get
            {
                if (!IsApplyDiscount)
                {
                    return null;
                }
                return Items.Sum(x => x.PriceByApplyDiscountRate);
            }
        }

        public void ApplyNewDiscount(string coupon, float discountRate)
        {
            Coupon = coupon;
            DiscountRate = discountRate;
            foreach (var item in Items)
            {
                item.PriceByApplyDiscountRate = item.Price * (decimal)(1 - discountRate);
            }
        }
        public void ApplyAvailableDiscount()
        {
            if (!IsApplyDiscount)
            {
                return;
            }
            foreach (var item in Items)
            {
                item.PriceByApplyDiscountRate = item.Price * (decimal)(1 - DiscountRate!);
            }
        }

        public void ClearDiscount()
        {
            Coupon = null;
            DiscountRate = null;
            foreach (var item in Items)
            {
                item.PriceByApplyDiscountRate = null;
            }
        }


    }
}
