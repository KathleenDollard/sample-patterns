namespace LiveryRegistration
{
    public record class Taxi(int Fares)
    { }

    public record class Bus(int Capacity, int Riders)
    { }

    // Each vehicle can be registered with multiple rideshare companies
    public record class Rideshare(int Passengers, int[] CompanyIds)
    { }
        /*
        : IEquatable<Rideshare>
    {
        public virtual bool Equals(Rideshare? other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;

            return (Passengers == other.Passengers)
                    && CompanyIds.SequenceEqual(other.CompanyIds);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Passengers);
            if (CompanyIds != null)
            {
                foreach (var id in CompanyIds)
                {
                    hash.Add(id);
                }
            }

            return hash.ToHashCode();
        }
    }
        */
}
