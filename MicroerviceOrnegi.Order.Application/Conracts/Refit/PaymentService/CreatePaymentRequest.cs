using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroerviceOrnegi.Order.Application.Conracts.Refit.PaymentService
{
    public record CreatePaymentRequest(
    string OrderCode,
    string CardNumber,
    string CardHolderName,
    string CardExpirationDate,
    string CardSecurityNumber,
    decimal Amount);
}
