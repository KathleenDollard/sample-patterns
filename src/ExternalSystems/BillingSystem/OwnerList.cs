using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class OwnerList
    {
        private readonly Dictionary<string, Owner> owners;

        private OwnerList(Dictionary<string, Owner> dictionary)
        {
            owners = dictionary;
        }

        public static OwnerList FetchOwners()
        {
            var dictionary = new Dictionary<string, Owner>();
            dictionary.Add("ID-TRE-LK", new Owner("Suzanne", "Wise"));
            dictionary.Add("AK-MNK-LIY", new Owner("Bill", "Nye"));
            dictionary.Add("WA-LLIIJJK", new Owner("Joe", "Blue"));

            return new OwnerList(dictionary);
        }

        public bool TryLookupOwner(string state, string plate, out Owner owner)
        {
            var id = $"{state}-{plate}";
            if (owners.TryGetValue(id, out owner))
            {
                if (owner != null)  // show both ! is null and is not null
                {
                    return true;
                }
            }
            return false;
        }
    }
}
