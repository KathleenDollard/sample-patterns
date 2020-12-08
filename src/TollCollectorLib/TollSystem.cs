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
        private static ILogger? s_logger;

        public static void Initialize(ILogger logger)
            => s_logger = logger;

        public static void AddEntry(object vehicle, DateTime time, bool inbound, string license)
        {
            s_logger?.SendMessage($"{time}: {(inbound ? "Inbound" : "Outbound")} {license} - {vehicle}");
            s_queue.Enqueue((vehicle, time, inbound, license));
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
                _ = accountList ?? throw new InvalidOperationException("Invalid county");
                Account? account = await accountList.LookupAccountAsync(license);
                if (account != null)
                {
                    account.Charge(toll);
                    s_logger?.SendMessage($"Charged: {license} {toll:C}");
                }
                else
                {
                    var finalToll = toll + 2.00m;
                    var state = license[^2..];
                    var plate = license[..^3];
                    var ownerList = OwnerList.FetchOwners();
                    if (ownerList.TryLookupOwner(state, plate, out var owner))
                    {
                        s_logger?.SendMessage($"Send bill: {owner.FirstName} {owner.LastName}: {license} {finalToll:C}");
                    }
                    s_logger?.SendMessage($"Can't send bill: {license} {finalToll:C}");
                }
            }
            catch (Exception ex)
            {
                s_logger?.SendMessage(ex.Message, LogLevel.Error);
            }
        }
    }
}
