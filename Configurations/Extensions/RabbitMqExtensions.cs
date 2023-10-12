using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using self_messaging.Configurations.Options;

namespace self_messaging.Configurations.Extensions
{
    public class RabbitMqExtensions
    {
        private readonly RabbitMQConfig _config;
        public RabbitMqExtensions(IOptions<RabbitMQConfig> config) => _config = config.Value;

        public string GetSelfQueueName() => _config.QueueName;

        public ConnectionFactory GetConnectionFactory()
        {
            return new ConnectionFactory
            {
                HostName = _config.HostName,
                UserName = _config.UserName,
                Password = _config.Password
            };
        }
    }
}
