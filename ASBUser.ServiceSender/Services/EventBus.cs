using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Text.Json;

namespace ASBUser.ServiceSender.Services
{
    public class EventBus : IEventBus
    {
        private readonly IConfiguration _configuration;

        public EventBus(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public async Task SendMessageAsync<T>(T serviceBusMessage, string queueName)
        {
            // Initialize the Queue
            var queueClient = new QueueClient(_configuration.GetConnectionString("AzureServiceBus"), queueName);

            // Convert the message object in JSON
            string messageBody = JsonSerializer.Serialize(serviceBusMessage);

            // Initialize the message
            var message = new  Message(Encoding.UTF8.GetBytes(messageBody));
            
            // send the message
            await queueClient.SendAsync(message);   

        }
    }
}
