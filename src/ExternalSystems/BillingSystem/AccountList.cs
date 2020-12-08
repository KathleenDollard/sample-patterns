using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class AccountList
    {
        private static readonly Random _random = new();
        private Dictionary<string, Account>? accounts;

        public IEnumerable<Account> GetAccounts()
            => accounts is null
                ? new List<Account>()
                : accounts.Select(x => x.Value);

        public static AccountList? FetchAccounts(string countyName)
            => countyName != "Test"
                ? null
                : new AccountList
                {
                    accounts = new Dictionary<string, Account>
                    {
                        { "BSF-846-WA", new Account("BSF-846-WA", new Owner("Greg", "Smith")) },
                        { "23456-WA", new Account("23456-WA", new Owner("Simon", "Jones")) },
                        { "AABBCC-DD-WA", new Account("AABBCC-DD-WA", new Owner("Sara", "Green")) }
                    }
                };

        public async Task<Account?> LookupAccountAsync(string license)
        {
            await Task.Delay(300);
            return accounts is null
                ? null
                : accounts.TryGetValue(license, out Account? account)
                    ? account
                    : null;
        }

        public static string GenerateTestLicense()
        {
            var states = new string[] { "BC", "CA", "ID", "OR", "WA" };
            var range = Enumerable.Range(0, _random.Next(4, 8) - 1);

            return string.Join("", range.Select(_ => NextRandCharacter()))
                        + "-" + states[_random.Next(1, states.Length) - 1];

            static string NextRandCharacter()
                => Convert.ToBoolean(_random.Next(0, 2))
                    ? ((char)('0' + _random.Next(0, 10))).ToString()
                    : ((char)('A' + _random.Next(0, 26))).ToString();
        }
    }
}
