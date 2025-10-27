using MicroerviceOrnegi.Web.Pages.Order.ViewModel;

namespace MicroerviceOrnegi.Web.Pages.Order.Dto
{
    public record GetOrderHistoryResponse(DateTime Created, decimal TotalPrice, List<OrderItemViewModel> Items);
}
