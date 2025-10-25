﻿using MicroerviceOrnegi.Web.Pages.Basket.Dto;
using Refit;

namespace MicroerviceOrnegi.Web.Services.Refit
{
    public interface IDiscountRefitService
    {
        [Get("/api/v1/discounts/{coupon}")]
        Task<ApiResponse<GetDiscountByCouponResponse>> GetDiscountByCoupon(string coupon);
    }
}
