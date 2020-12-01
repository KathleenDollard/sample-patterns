using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class Account
    {
        private static readonly Random _random = new Random();

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

        public static string GenerateTestLicense()
        {
            var states = new string[] { "BC", "CA", "ID", "OR", "WA" };

            var builder = new StringBuilder();
            var numberLength = _random.Next(4, 8);

            for (int i = 0; i < numberLength; i++)
            {
                if (Convert.ToBoolean(_random.Next(0, 2)))
                {
                    builder.Append((char)('0' + _random.Next(0, 10)));
                }
                else
                {
                    builder.Append((char)('A' + _random.Next(0, 26)));
                }
            }

            builder.Append('-');

            builder.Append(states[_random.Next(1, states.Length) - 1]);

            return builder.ToString();
        }
    }
}

