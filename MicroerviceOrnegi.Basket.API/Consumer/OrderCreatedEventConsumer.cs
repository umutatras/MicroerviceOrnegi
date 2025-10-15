using MassTransit;
using MicroerviceOrnegi.Basket.API.Features;
using MicroerviceOrnegi.Bus.Events;

namespace MicroerviceOrnegi.Basket.API.Consumer;

public class OrderCreatedEventConsumer(IServiceProvider serviceProvider) : IConsumer<OrderCreatedEvent>
{
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        using var scope = serviceProvider.CreateScope();
        var basketService = scope.ServiceProvider.GetRequiredService<BasketService>();
        await basketService.DeleteBasket(context.Message.UserId);
    }
}