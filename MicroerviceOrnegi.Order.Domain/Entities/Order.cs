using MassTransit;
using System.Text;


namespace MicroerviceOrnegi.Order.Domain.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public string Code { get; set; } = default!;
        public DateTime Created { get; set; }

        public Guid BuyerId { get; set; }
        public OrderStatus Status { get; set; }
        public int AddressId { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid PaymentId { get; set; }
        public float? DiscountRate { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
        public Address Address { get; set; } = null!;
        public static string GenerateCode()
        {
            Random random = new Random();
            var ordercode = new StringBuilder(10);

            for (int i = 0; i < 10; i++)
            {
                ordercode.Append(random.Next(0, 10));
            }
            return ordercode.ToString();
        }

        public static Order CreateUnPaidOrder(Guid buyerId, float discountRate, int addressId)
        {
            return new Order
            {
                Id = NewId.NextGuid(),
                Code = GenerateCode(),
                Created = DateTime.UtcNow,
                BuyerId = buyerId,
                Status = OrderStatus.WaitingForPayment,
                AddressId = addressId,
                TotalPrice = 0,
                DiscountRate = discountRate
            };
        }
        public void AddOrderItem(Guid productId, string productName, decimal unitPrice)
        {
            var orderItem = new OrderItem();
            orderItem.SetItem(productId, productName, unitPrice);
            OrderItems.Add(orderItem);
            CalculateTotalPrice();
        }
        private void CalculateTotalPrice()
        {
            decimal total = OrderItems.Sum(item => item.UnitPrice);
            if (DiscountRate.HasValue && DiscountRate.Value > 0)
            {
                total -= total * (decimal)(DiscountRate.Value / 100);
            }
            TotalPrice = total;
        }
        public void ApplyDiscount(float discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 100)
                throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 100");
            DiscountRate = discountPercentage;
            CalculateTotalPrice();
        }
        public void SetPaidStatus(Guid paymentId)
        {
            if (Status == OrderStatus.Paid)
                throw new InvalidOperationException("Order is already marked as paid.");
            PaymentId = paymentId;
            Status = OrderStatus.Paid;
        }
    }
    public enum OrderStatus
    {
        WaitingForPayment = 1,
        Paid = 2,
        Cancel = 3
    }
}
