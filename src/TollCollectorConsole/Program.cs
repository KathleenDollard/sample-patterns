using Common;
using System;
using TollCollectorLib;
using ConsumerVehicleRegistration;
using TollCollectorLib.BillingSystem;

namespace TollCollectorConsole
{
    class Program
    {
        static async System.Threading.Tasks.Task Main()
        {
            var owner = new Owner(
                firstName: "Vanessa",
                lastName: "Green"
            );

            var logger = new Logger();
            TollSystem.Initialize(logger);

            Demo.Output();

            await TollSystem.ChargeTollAsync(
                new Car(Passengers: 2),
                time: DateTime.Now,
                inbound: true,
                license: "BSF-846-WA");

            //DoTheGreenDemo();

        }

        private class Logger : ILogger
        {
            public void SendMessage(string message, LogLevel logLevel)
                => Console.WriteLine(message);
        }

        //private void DoTheGreenDemo()
        //{
        //    var cycle = new Cycle(riders: 1, 1);
        //    var points = GreenPointSystem.GetPoints(cycle);
        //    logger.SendMessage($"Green! {cycle.Riders}/{cycle.Wheels} Points: {points}", LogLevel.Info);
        //}
    }
}
