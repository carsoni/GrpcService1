using Grpc.Core;
using GrpcService1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static GrpcService1.Greeter;
using Grpc.Net.Client;

namespace GrpcClient1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var channel = GrpcChannel.ForAddress("https://localhost:5001");
                var client = new GreeterClient(channel);
                var reply = await client.SayHelloAsync(new HelloRequest { Name = "Ian" });
                Console.WriteLine(reply.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }

            Console.ReadLine();
        }
    }
}
