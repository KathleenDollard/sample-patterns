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

            public string State { get; set; }

            public string Plate { get; set; }
        }
    }

}
