using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQDemo.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    while (true)
                    {
                        Console.WriteLine("Type your message");

                        var teste = Console.ReadLine();

                        channel.QueueDeclare(
                            queue: "tests",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

                        string message =
                            $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - " +
                            $"Message content: {teste}";
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                                             routingKey: "tests",
                                             basicProperties: null,
                                             body: body);
                    }
                }
            }
        }
    }
}