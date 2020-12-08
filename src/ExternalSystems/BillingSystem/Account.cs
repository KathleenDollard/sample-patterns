namespace TollCollectorLib.BillingSystem
{
    public class Account
    {
        public Account(string license, Owner owner)
        {
            License = license;
            Owner = owner;
        }

        public Owner Owner { get; private set; }

        public string License { get; }

        public string State 
            => License[^2..];
    }
}

