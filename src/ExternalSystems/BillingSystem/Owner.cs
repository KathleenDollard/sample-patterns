namespace TollCollectorLib
{
    namespace BillingSystem
    {

        public class Owner
        {
            public Owner(string firstName, string lastName, string? middleName = null)
            {
                FirstName = firstName;
                LastName = lastName;
                MiddleName = middleName;
            }

            public string FirstName { get; init; }
            public string? MiddleName { get; init; }
            public string LastName { get; init; }
        }

    }
}
