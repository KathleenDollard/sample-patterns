namespace TollCollectorLib.BillingSystem
{
    public class Account
    {
        public Account(string license, Owner owner)
        {
            License = license;
            Owner = owner;
        }

        public Account()
        {        }

        public Owner Owner { get; init ; }

        public string License { get; init; }

        public string State 
            => License[^2..];
    }
}

