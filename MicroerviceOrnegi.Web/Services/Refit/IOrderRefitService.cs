using MicroerviceOrnegi.Web.Pages.Order.Dto;
using Refit;

namespace MicroerviceOrnegi.Web.Services.Refit
{
    public interface IOrderRefitService
    {
        [Post("/api/v1/orders")]
        Task<ApiResponse<object>> CreateOrder(CreateOrderRequest request);

        [Get("/api/v1/orders")]
        Task<ApiResponse<List<GetOrderHistoryResponse>>> GetOrders();
    }
}
