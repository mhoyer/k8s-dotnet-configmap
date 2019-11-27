using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace K8sConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            var currentConfigValue = config["foo"];
            Console.WriteLine($"Initial config value: {currentConfigValue}");

            while(true)
            {
                if (currentConfigValue == config["foo"]) {
                    Thread.Sleep(2);
                    continue;
                }

                currentConfigValue = config["foo"];
                Console.WriteLine($"{currentConfigValue}");
            }
        }
    }
}
