using System;

using Grpc.Core;
using Helloworld;

namespace Core.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个长连接的channel（不加密、不安全的）
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            
            var client = new Greeter.GreeterClient(channel);
            String user = "zhangsan";

            var reply = client.SayHello(new HelloRequest { Name = user });
            Console.WriteLine("Greeting: " + reply.Message);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
