using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using self_messaging.Events;
using self_messaging.Hubs;
using self_messaging.Interfaces;

namespace self_messaging.Controllers;

public class MessageController : Controller
{
    private readonly ILogger<MessageController> _logger;
    private readonly IRabbitMQSender _sender;


    public MessageController(
        ILogger<MessageController> logger,
        IRabbitMQSender sender)
    {
        _logger = logger;
        _sender = sender;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendMessage(string message)
    {
        Guid id = Guid.NewGuid();

        var messageEvent = new MessageEvent(id, message);
        _sender.Send(messageEvent);
        _logger.LogInformation($"Mensage enviada: {message}");
        return Json(new { success = true, Id = messageEvent.Id });
    }
}
