using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            using ILoggerFactory factory = LoggerFactory.Create( (builder) => builder.AddConsole());
            
            ILogger logger = factory.CreateLogger("Program1");

            logger.LogInformation("Hello World! Logging is {Description}.", "fun");
        }
    }
}
