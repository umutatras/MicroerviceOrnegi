﻿using MassTransit;
using MicroerviceOrnegi.Bus;
using MicroerviceOrnegi.File.API.Consumers;

namespace MicroerviceOrnegi.File.API
{
    public static class MasstransitConfigurationExt
    {
        public static IServiceCollection AddMasstransitExt(this IServiceCollection services,
            IConfiguration configuration)
        {
            var busOptions = configuration.GetSection(nameof(BusOption)).Get<BusOption>()!;


            services.AddMassTransit(configure =>
            {
                configure.AddConsumer<UploadCoursePictureCommandConsumer>();


                configure.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri($"rabbitmq://{busOptions.Address}:{busOptions.Port}"), host =>
                    {
                        host.Username(busOptions.UserName);
                        host.Password(busOptions.Password);
                    });

                    cfg.ReceiveEndpoint("file-microservice.upload-course-picture-command.queue",
                        e => { e.ConfigureConsumer<UploadCoursePictureCommandConsumer>(ctx); });


                    // cfg.ConfigureEndpoints(ctx);
                });
            });


            return services;
        }
    }
}
