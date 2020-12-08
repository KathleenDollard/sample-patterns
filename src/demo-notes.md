# Demo Notes

## Code Simplification

1. Open file for first point - Account
   * Remove `this` as sample of how analyzers used
   * Fix auto props
2. Walk through next few. On return to FetchAccounts
         public static AccountList FetchAccounts(string countyName) 
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
3. GenerateTestLicense
   * StringBuilder is almost certainly not helping. Remove.
   *         public static string GenerateTestLicense()
        {
            var states = new string[] { "BC", "CA", "ID", "OR", "WA" };
            var range = Enumerable.Range(0, _random.Next(4, 8) - 1);

            return string.Join("", range.Select(x => GetNextCharacter()))
                    + "-" + states[_random.Next(1, states.Length) - 1];

            static string GetNextCharacter()
            {
                return Convert.ToBoolean(_random.Next(0, 2))
                    ? ((char)('0' + _random.Next(0, 10))).ToString()
                    : ((char)('A' + _random.Next(0, 26))).ToString();
            }
        }