using ASBShared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Text.Json;

namespace ASBEmail.ServiceReceiver.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private IQueueClient queueClient;

        public HomeController(IConfiguration configuration,IQueueClient queueClient)
        {
            this.configuration = configuration;
            this.queueClient = queueClient;
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            queueClient = new QueueClient(configuration.GetConnectionString("AzureServiceBus"), configuration.GetSection("AzureQueue").Value!);

            var messageOptions = new MessageHandlerOptions(ExceptionReceiverHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            queueClient.RegisterMessageHandler(ProcessMessageAsync, messageOptions);

            await queueClient.CloseAsync();

            return Ok("Email Send successfully!");
        }


        [NonAction]
        public async Task ProcessMessageAsync(Message message, CancellationToken cancellationToken)
        {
            var jsonBody = Encoding.UTF8.GetString(message.Body);
            var msgObj = JsonSerializer.Deserialize<User>(jsonBody);

            // Logic To Send The Email
            Console.WriteLine(msgObj.Email);

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);

        }
        
        [NonAction]
        public async Task<IActionResult> ExceptionReceiverHandler(ExceptionReceivedEventArgs ex)
        {
            return new JsonResult(ex.Exception.Message);

        }
    }
}