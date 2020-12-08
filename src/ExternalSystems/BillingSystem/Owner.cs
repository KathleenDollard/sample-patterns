using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TollCollectorLib
{
    namespace BillingSystem
    {

        public class Owner
        {
            private string firstName;
            private string middleName;
            private string lastName;

            public Owner(string firstName, string lastName, string middleName = null)
            {
                FirstName = firstName;
                LastName = lastName;
                MiddleName = middleName;
            }

            public string FirstName
            {
                get
                {
                    return firstName;
                }

                set
                {
                    firstName = value;
                }
            }
            public string MiddleName
            {
                get
                {
                    return middleName;
                }

                set
                {
                    middleName = value;
                }
            }
            public string LastName
            {
                get
                {
                    return lastName;
                }

                set
                {
                    lastName = value;
                }
            }
        }
    }

}
