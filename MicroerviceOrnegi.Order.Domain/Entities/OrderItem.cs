namespace MicroerviceOrnegi.Order.Domain.Entities
{
    public class OrderItem : BaseEntity<int>
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public void SetItem(Guid productId, string productName, decimal unitPrice)
        {
            if (string.IsNullOrEmpty(productName))
                throw new ArgumentNullException(nameof(productName));

            if (unitPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(unitPrice), "UnitPrice cannot be negative");

            this.ProductId = productId;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "UnitPrice cannot be negative");
            this.UnitPrice = newPrice;
        }

        public void ApplyDiscount(float discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 100");
            this.UnitPrice = this.UnitPrice - (this.UnitPrice * (decimal)(discountPercentage / 100));
        }

        public bool IsSameItem(OrderItem otherItem)
        {
            return this.ProductId == otherItem.ProductId;
        }
    }
}
