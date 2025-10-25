using MicroerviceOrnegi.Web.PageModels;
using MicroerviceOrnegi.Web.Pages.Order.ViewModel;
using MicroerviceOrnegi.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroerviceOrnegi.Web.Pages.Order
{
    public class CreateModel(BasketService basketService, OrderService orderService) : BasePageModel
    {
        [BindProperty] public CreateOrderViewModel CreateOrderViewModel { get; set; } = CreateOrderViewModel.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadInitialFormData();

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            await LoadInitialFormData();
            if (!ModelState.IsValid) return Page();


            var result = await orderService.CreateOrder(CreateOrderViewModel);

            return result.IsFail
                ? ErrorPage(result)
                : SuccessPage("order created successfully", "/Order/Result");
        }

        private async Task LoadInitialFormData()
        {
            var basketAsResult = await basketService.GetBasketsAsync();

            if (basketAsResult.IsFail)
            {
                ErrorPage(basketAsResult);
                return;
            }

            CreateOrderViewModel.TotalPrice =
                basketAsResult.Data.TotalPriceWithAppliedDiscount ?? basketAsResult.Data!.TotalPrice;

            CreateOrderViewModel.DiscountRate = basketAsResult.Data.DiscountRate;
            foreach (var basketItem in basketAsResult.Data!.Items) CreateOrderViewModel.AddOrderItem(basketItem);
        }
    }
}
