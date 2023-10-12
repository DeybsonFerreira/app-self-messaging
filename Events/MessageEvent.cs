namespace self_messaging.Events;

public class MessageEvent
{
    public MessageEvent(Guid id, string message)
    {
        Id = id;
        Message = message;
    }

    public Guid Id { get; set; }
    public string Message { get; set; }
}

