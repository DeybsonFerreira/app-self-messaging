using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using self_messaging.Configurations.Extensions;
using self_messaging.Configurations.Options;
using self_messaging.Events;
using self_messaging.Hubs;

namespace self_messaging.BackgroundServices;
public class RabbitMQReceiverService : BackgroundService
{
    private readonly IOptions<RabbitMQConfig> _config;
    private readonly IHubContext<MessageHub> _hubContext;

    public RabbitMQReceiverService(
        IOptions<RabbitMQConfig> config,
        IHubContext<MessageHub> hubContext)
    {
        _config = config;
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        RabbitMqExtensions rabbitMqExtensions = new(_config);
        var factory = rabbitMqExtensions.GetConnectionFactory();
        var queueName = rabbitMqExtensions.GetSelfQueueName();

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var messageEvent = JsonConvert.DeserializeObject<MessageEvent>(message);

            //3segundos para atualizar a tela
            await Task.Delay(3000);

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", new
            {
                messageEvent.Id,
                Status = "success"
            });
        };

        channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}
