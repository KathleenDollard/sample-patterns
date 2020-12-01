using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TollCollectorLib.BillingSystem
{
    public class OwnerList
    {
        private Dictionary<string, Owner> owners;

        public OwnerList()
        { }

        public bool TryLookupOwner(string id, out Owner owner)
        {
            if (owners.TryGetValue(id, out owner))
            {
                if (!(owner is null))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
