namespace ASBUser.ServiceSender.Services
{
    public interface IEventBus
    {
        Task SendMessageAsync<T>(T serviceBusMessage, string queueName);
    }
}
