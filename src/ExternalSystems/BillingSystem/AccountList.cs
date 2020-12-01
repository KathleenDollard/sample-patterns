using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class AccountList
    {
        private static readonly Random _random = new Random();
        private Dictionary<string, Account> accounts;

        private AccountList()
        {
        }


        public IEnumerable<Account> GetAccounts()
        {
            return accounts.Select(x => x.Value);
        }

        public static AccountList FetchAccounts(string countyName)
        {
            var ret = new AccountList();
            if (countyName != "Test")
            {
                return null;
            }

            ret.accounts = new Dictionary<string, Account>();
            ret.accounts.Add("BSF-846-WA", new Account("BSF-846-WA", new Owner("Greg", "Smith")));
            ret.accounts.Add("23456-WA", new Account("23456-WA", new Owner("Simon", "Jones")));
            ret.accounts.Add("AABBCC-DD-WA", new Account("AABBCC-DD-WA", new Owner("Sara", "Green")));

            return ret;
        }

        public async Task<Account> LookupAccountAsync(string license)
        {
            await Task.Delay(300);
            Account account = null;
            if (accounts.TryGetValue(license, out account))
            {
                return account;
            }
            throw new NotImplementedException();
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
