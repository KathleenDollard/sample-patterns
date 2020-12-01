using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string State
        {
            get
            {
                return license.Substring(license.Length - 2);
            }
        }
    }
}

