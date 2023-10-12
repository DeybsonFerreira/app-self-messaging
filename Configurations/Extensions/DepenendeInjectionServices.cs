using self_messaging.BackgroundServices;
using self_messaging.Configurations.Options;
using self_messaging.Interfaces;
using self_messaging.Messaging;

namespace self_messaging.Configurations.Extensions
{
    public static class DepenendeInjectionServices
    {
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RabbitMQConfig>(config.GetSection("RabbitMQ"));
            services.AddHostedService<RabbitMQReceiverService>();
            services.AddScoped<IRabbitMQSender, RabbitMQSender>();
            services.AddSignalR();
            return services;
        }
    }
}
