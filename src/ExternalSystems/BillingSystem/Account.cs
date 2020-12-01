using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class Account
    {
        public Account(string license, Owner owner)
        {
            this.license = license;
            this.Owner = owner;
        }

        private readonly string license;
        private Owner owner;

        public Owner Owner
        {
            get { return owner; }
            private set
            {
                owner = value;
            }
        }

        public string License
        {
            get
            {
                return license;
            }
        }
    }
}

