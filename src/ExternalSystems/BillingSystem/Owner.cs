using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TollCollectorLib
{
    namespace BillingSystem
    {

        public class Owner
        {
            private string state;
            private string plate;
            private string firstName;
            private string middleName;
            private string lastName;

            public Owner(string state, string plate)
            {
                State = state;
                Plate = plate;
            }

            public string FirstName
            {
                get => firstName; set => firstName = value;
            }
            public string MiddleName
            {
                get => middleName; set => middleName = value;
            }
            public string LastName
            {
                get => lastName; set => lastName = value;
            }

            public string State
            {
                get
                {
                    return state;
                }
                set
                {
                    state = value;
                }
            }

            public string Plate
            {
                get
                {
                    return plate;
                }
                set
                {
                    plate = value;
                }
            }
        }
    }

}
