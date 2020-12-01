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

            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }

            public string State { get; }
            public string Plate { get; }

 


        }
    }

}
