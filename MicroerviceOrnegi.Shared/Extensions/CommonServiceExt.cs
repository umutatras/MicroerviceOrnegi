using FluentValidation;
using MicroerviceOrnegi.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MicroerviceOrnegi.Shared.Extensions
{
    public static class CommonServiceExt
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services, Type assembly)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(assembly));
            services.AddValidatorsFromAssemblyContaining(assembly);
            services.AddAutoMapper(assembly);
            services.AddScoped<IIdentityService, IdentityService>();
            return services;
        }
    }
}
