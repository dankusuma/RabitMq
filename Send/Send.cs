using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
       int i =0;
        while(i==0)
        {
            Console.WriteLine("Masukan Pesan :");
            string message = Console.ReadLine();
            send(message);
        }

    }

    public static void send(string message)
    {
        var factory = new ConnectionFactory() { HostName = "139.59.117.173" };
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "logs", routingKey: "", basicProperties: null, body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }
    }

}