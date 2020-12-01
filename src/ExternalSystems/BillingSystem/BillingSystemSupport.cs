using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public  static  class BillingSystemSupport
    {
        public static void Charge(this Account account, decimal toll)
        {
            // Dummy charge action
            Console.WriteLine($"Charging toll: {toll}");
        }

        public static void SendBill(decimal finalToll)
        {
            // Dummy send Bill Action
            Console.WriteLine($"Sending bill: {finalToll}");
        }

    }
}
