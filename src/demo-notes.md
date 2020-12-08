# Demo Notes

## Code Simplification

1. Open file for first point - Account
   * Remove `this` as sample of how analyzers used
   * Fix auto props
2. Change Directory.Build.Props
2. Walk through next few. On return to FetchAccounts
   
```c#
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
```

1. GenerateTestLicense
   * StringBuilder is almost certainly not helping. Remove.

```c#
public static string GenerateTestLicense()
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
```

1. Follow rest of slide
2. Binary literals - Which is longer

```c#
        ReallyBad = 0b10000000000,
        Worse = 0b100000000000,
```

1. At some point - clean up other warnings 

## General correctness

1. Immutable support: Create a new OWNER in Main and desire to use object initialization.
   1. Why is object initialization better in some case?
      1. After updating to init, you will get error about External Init. Change TFM to .NET 5
      2. ~~Then when you build, you will get an error on WPF
      3. Dumb Constructor anyway, Add to constructor~~
2. Await in catch/finally
3. Async Main - 
   1. run first to show why we need async
   2. Comment out demo and run 
   3. Async doesn't matter here, something has to await
4. Tuples: remove QueueEntry
   1. Copy the constructor args, and delete
   2. Make tuple of constructor args
   3. Create a temp variable to see how access occurs. Make it a var.

## Null Correctness

1. Why `is null` instead of `== null`?
   1.  search = null - tollcalculator
2. Null reference types: Set in Directory.Build.Props
   1. Use file filters to filter to Owner. Fix and remove parameterless constructor
   2. AccountList : 
      1. Let accounts be nullable, and FetchAccounts
      2. What should GetAccounts do? 
         1. Throw, no valid value possible?
         2. Empty list, no value found? DO THIS ONE
         3. null and propagate the problem?
      3. Fix LookupAccountAsync

```c#
    await Task.Delay(300);
    return accounts is null
        ? null
        : accounts.TryGetValue(license, out Account? account)
            ? account
            : null;
```

   1. OwnerList
   2. TollSystem:
      1. Make ILogger nullable
      2. Use null conditional , Elvis operator for SendMessage
      3. Null Coalescing

```c#
    _ = accountList ?? throw new InvalidOperationException("Invalid county");
```

      4. ChargeTollAsync: Looking up account logic failure

```c#
var accountList = AccountList.FetchAccounts(countyName: "Test");
_ = accountList ?? throw new InvalidOperationException("Invalid county");
Account? account = await accountList.LookupAccountAsync(license);
if (account != null)
{
    account.Charge(toll);
    s_logger?.SendMessage($"Charged: {license} {toll:C}");
}
else
{
    var finalToll = toll + 2.00m;
    var state = license[^2..];
    var plate = license[..^3];
    var ownerList = OwnerList.FetchOwners();
    if (ownerList.TryLookupOwner(state, plate, out var owner))
    {
        s_logger?.SendMessage($"Send bill: {owner.FirstName} {owner.LastName}: {license} {finalToll:C}");
    }
    s_logger?.SendMessage($"Can't send bill: {license} {finalToll:C}");
}
```

        1. TryLookupOwner - put NotNull on out param

```c#
        public bool TryLookupOwner(string state, string plate, [NotNullWhen(true)] out Owner? owner)
        {

```
