using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using TollCollectorLib.BillingSystem;
using ConsumerVehicleRegistration;
using Common;
using System.Collections.Generic;

namespace TollCollectorLib
{
    public static class TollSystem
    {
        private static readonly ConcurrentQueue<(object vehicle, DateTime time, bool inbound, string license)> s_queue
           = new();
            public readonly object Vehicle;
            public readonly DateTime Time;
            public readonly bool Inbound;
            public readonly string License;

            public QueueEntry(object vehicle, DateTime time, bool inbound, string license)
            {
                Vehicle = vehicle;
            var item = (vehicle, time, inbound, license);
            s_queue.Enqueue(item);
                Inbound = inbound;
                License = license;
            }
        }

        private static readonly ConcurrentQueue<QueueEntry> s_queue
            = new();
        private static ILogger s_logger;

        public static void Initialize(ILogger logger)
            => s_logger = logger;

        public static void AddEntry(object vehicle, DateTime time, bool inbound, string license)
        {
            s_logger.SendMessage($"{time}: {(inbound ? "Inbound" : "Outbound")} {license} - {vehicle}");
            s_queue.Enqueue(new QueueEntry(vehicle, time, inbound, license));
        }

        public static async Task ChargeTollAsync(
            object vehicle,
            DateTime time,
            bool inbound,
            string license)
        {
            try
            {
                var baseToll = TollCalculator.CalculateToll(vehicle);
                var peakPremium = TollCalculator.PeakTimePremium(time, inbound);
                var toll = baseToll * peakPremium;

                var accountList = AccountList.FetchAccounts(countyName: "Test");
                Account account = await accountList.LookupAccountAsync(license);

                account.Charge(toll);
                s_logger.SendMessage($"Charged: {license} toll:C");
            }
            catch (Exception ex)
            {
                s_logger.SendMessage(ex.Message, LogLevel.Error);
            }
        }
    }
}
