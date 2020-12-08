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
            return  new OwnerList(new Dictionary<string, Owner>
                            {
                                { "ID-TRE-LK",  new Owner( "Suzanne",  "Wise")},
                                { "AK-MNK-LIY",  new Owner( "Bill",  "Nye") },
                                { "WA-LLIIJJK",  new Owner( "Joe",  "Blue") }
                            }
                         );
        }

        public bool TryLookupOwner(string state, string plate, out Owner? owner)
        {
            var id = $"{state}-{plate}";
            if (owners.TryGetValue(id, out owner))
            {
                if (owner is not null)  // show both ! is null and is not null
                {
                    return true;
                }
            }
            return false;
        }
    }
}
