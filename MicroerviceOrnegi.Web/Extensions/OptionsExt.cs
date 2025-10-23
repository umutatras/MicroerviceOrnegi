﻿using MicroerviceOrnegi.Web.Options;
using Microsoft.Extensions.Options;

namespace MicroerviceOrnegi.Web.Extensions;

public static class OptionsExt
{
    public static IServiceCollection AddOptionsExt(this IServiceCollection services)
    {
        services.AddOptions<IdentityOption>().BindConfiguration(nameof(IdentityOption)).ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton<IdentityOption>(sp => sp.GetRequiredService<IOptions<IdentityOption>>().Value);


        return services;
    }
}