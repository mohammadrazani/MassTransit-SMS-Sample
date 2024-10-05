using MassTransit;
using Messaging.Consumers;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging
{
    public static class MassTransitConfiguration
    {
        public static IServiceCollection AddMassTransitWithRabbitMq(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<SmsConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("sms-queue", e =>
                    {
                        e.ConfigureConsumer<SmsConsumer>(context);
                    });
                });
            });

            return services;
        }
    }
}
