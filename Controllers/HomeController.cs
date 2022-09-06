using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kafka_Dotnet_Simple_Example.Models;
using Confluent.Kafka;

namespace Kafka_Dotnet_Simple_Example.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProducer<Null, string> _producer;

    public HomeController(ILogger<HomeController> logger, IProducer<Null, string> producer)
    {
        _logger = logger;
        _producer = producer;
    }

    [HttpPost] 
    public ActionResult SendEvent(string eventMessage)
    {   //TODO: Make Async and get return value
        //Send the message to Kafka instance and return Index to reload this page
        _producer.Produce("MyTopic", new Message<Null, string> { Value = eventMessage });
        return View("Index");
    }

    public IActionResult Index()
    {        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
