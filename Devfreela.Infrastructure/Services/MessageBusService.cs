using Devfreela.Core.Services;
using DevFreela.Shared.Models.UI;
using RabbitMQ.Client;

namespace Devfreela.Infrastructure.Services
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _factory;

        public MessageBusService(ApiSettings apiSettings)
        {
            _factory = CreateConnectionFactory(apiSettings);
        }

        private ConnectionFactory CreateConnectionFactory(ApiSettings apiSettings)
        {
            return new ConnectionFactory
            {
                HostName = apiSettings.Services.RabbitMQ
            };
        }

        public void Publish(string queue, byte[] message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    DeclareQueue(queue, channel);
                    PublishMessage(queue, message, channel);
                }
            }
        }

        private static void PublishMessage(string queue, byte[] message, IModel channel)
        {
            channel.BasicPublish(
                                    exchange: "",
                                    routingKey: queue,
                                    basicProperties: null,
                                    body: message);
        }

        private static void DeclareQueue(string queue, IModel channel)
        {
            channel.QueueDeclare(
                                    queue: queue,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }
    }
}
