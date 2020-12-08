using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TollCollectorLib
{
    namespace BillingSystem
    {

        public class Owner
        {
            public Owner(string state, string plate)
            {
                State = state;
                Plate = plate;
            }

            public Owner()
            { }

            public string FirstName { get; init; }
            public string MiddleName { get; init; }
            public string LastName { get; init; }

            public string State { get; init; }

            public string Plate { get; init; }
        }
    }

}
