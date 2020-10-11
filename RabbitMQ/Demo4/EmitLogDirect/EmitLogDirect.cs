using System.Threading;
using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;

class EmitLogDirect
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.ExchangeDeclare(exchange: "direct_logs",
                                    type: "direct");
            while (true)
            {
                // dotnet run info
                // dotnet run warning
                // dotnet run error
                var severity = (args.Length > 0) ? args[0] : "info";
                var message = $"[{DateTime.Now}] Some {severity} message!";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "direct_logs",
                                     routingKey: severity,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
                Thread.Sleep(1000);
            }

        }
    }
}