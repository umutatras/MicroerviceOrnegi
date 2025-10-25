using MicroerviceOrnegi.Web.PageModels;
using MicroerviceOrnegi.Web.Pages.Order.ViewModel;
using MicroerviceOrnegi.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroerviceOrnegi.Web.Pages.Order
{
    [Authorize]
    public class HistoryModel(OrderService orderService) : BasePageModel
    {
        public List<OrderHistoryViewModel> OrderHistoryList { get; set; } = null!;

        public async Task<IActionResult> OnGet()
        {
            var response = await orderService.GetHistory();


            if (response.IsFail) return ErrorPage(response);

            OrderHistoryList = response.Data!;


            return Page();
        }
    }
}
