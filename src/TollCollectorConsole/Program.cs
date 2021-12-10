using Common;
using System;
using TollCollectorLib;
using ConsumerVehicleRegistration;
using System.Threading.Tasks;

namespace TollCollectorConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var logger = new Logger();
            TollSystem.Initialize(logger);

            Demo.Output();

            await TollSystem.ChargeTollAsync(
                 new Car(2),
                 time: DateTime.Now,
                 inbound: true,
                 license: "BSF-846-WA");

            //DoTheGreenDemo();

            //For the async demo, switch the startup project to TollCollectorApp

            //void DoTheGreenDemo()
            //{
            //    var cycle = new Cycle(riders: 1, 1);
            //    var points = GreenPointSystem.GetPoints(cycle);
            //    logger.SendMessage($"Green! {cycle.Riders}/{cycle.Wheels} Points: {points}", LogLevel.Info);
            //}
        }

        private class Logger : ILogger
        {
            public void SendMessage(string message, LogLevel logLevel)
                => Console.WriteLine(message);
        }
    }
}