using self_messaging.Events;

namespace self_messaging.Interfaces;
public interface IRabbitMQSender
{
    void Send(MessageEvent message);
}