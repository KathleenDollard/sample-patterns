using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class OwnerList
    {
        private readonly Dictionary<string, Owner> owners;

        public OwnerList()
        { }

        public bool TryLookupOwner(string id, out Owner owner)
        {
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
