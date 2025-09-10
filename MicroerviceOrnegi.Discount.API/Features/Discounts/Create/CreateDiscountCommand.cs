﻿using MicroerviceOrnegi.Shared;

namespace MicroerviceOrnegi.Discount.API.Features.Discounts.Create
{
    public record CreateDiscountCommand(string Code, float Rate, Guid UserId, DateTime Expired) : IRequestByServiceResult;

}
