using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using self_messaging.Configurations.Extensions;
using self_messaging.Configurations.Options;
using self_messaging.Events;
using self_messaging.Interfaces;

namespace self_messaging.Messaging;

public class RabbitMQSender : RabbitMqExtensions, IRabbitMQSender
{
    public RabbitMQSender(IOptions<RabbitMQConfig> config) : base(config)
    {
    }

    public void Send(MessageEvent message)
    {
        var factory = GetConnectionFactory();
        var queueName = GetSelfQueueName();


        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var jsonMessage = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(jsonMessage);

        channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);
    }
}


