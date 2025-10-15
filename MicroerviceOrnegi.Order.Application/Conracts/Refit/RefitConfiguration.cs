using MicroerviceOrnegi.Order.Application.Conracts.Refit.PaymentService;
using MicroerviceOrnegi.Shared.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroerviceOrnegi.Order.Application.Conracts.Refit;

public static class RefitConfiguration
{
    public static IServiceCollection AddRefitConfigurationExt(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddRefitClient<IPaymentService>().ConfigureHttpClient(configure =>
        {
            var addressUrlOption = configuration.GetSection(nameof(AddressUrlOption)).Get<AddressUrlOption>();


            configure.BaseAddress = new Uri(addressUrlOption!.PaymentUrl);
        });


        return services;
    }
}