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

            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }

            public string State { get; set; }

            public string Plate { get; set; }
        }
    }

}
