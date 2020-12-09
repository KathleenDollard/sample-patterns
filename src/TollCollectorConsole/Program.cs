using Common;
using System;
using TollCollectorLib;
using ConsumerVehicleRegistration;
using TollCollectorLib.BillingSystem;

namespace TollCollectorConsole
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var logger = new Logger();
            TollSystem.Initialize(logger);

            var owner = new Owner(
                firstName: "Fred",
                lastName: "Silberberg"
            );

            // Demo.Output();

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
