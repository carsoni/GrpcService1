using System;
using System.IO;
using System.Net;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GrpcService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("GRPC_TRACE", "api");
            Environment.SetEnvironmentVariable("GRPC_VERBOSITY", "debug");
            GrpcEnvironment.SetLogger(new Grpc.Core.Logging.ConsoleLogger());
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.ConfigureKestrel((context, options) =>
                    //{
                    //    // Support --port and --use_tls cmdline arguments normally supported
                    //    // by gRPC interop servers.
                    //    var port = context.Configuration.GetValue<int>("port", 5001);
                    //    var useTls = context.Configuration.GetValue<bool>("use_tls", true);

                    //    options.Limits.MinRequestBodyDataRate = null;
                    //    options.Listen(new IPAddress(IPAddress.Parse("0.0.0.0").GetAddressBytes()), port, listenOptions =>
                    //    {
                    //        Console.WriteLine($"Enabling connection encryption: {useTls}");

                    //        if (useTls)
                    //        {
                    //            //var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                    //            var basePath = @"C:\Users\Ian.PARADIGM\Documents\Visual Studio 2019";
                    //            var certPath = Path.Combine(basePath!, "DevCert.pfx");

                    //            listenOptions.UseHttps(certPath, "Axoaxo544!");
                    //        }
                    //        listenOptions.Protocols = HttpProtocols.Http2;
                    //    });
                    //});
                    webBuilder.UseStartup<Startup>();
                });
    }
}
