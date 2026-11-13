namespace Narnia.VehicleRegistrations.LiveryRegistration
{
    public record class Taxi();

    public record class Bus(int Capacity);

    // Each vehicle can be registered with multiple rideshare companies
    // This is only used to demonstrate deep equality in this demo.
    public record class Rideshare(int[] CompanyIds)
    { }

    /*
{    
    public virtual bool Equals(Rideshare? other)
    {
        if (ReferenceEquals(this, other)) return true;
        if (other is null) return false;

        // Use a tuple if you have multiple fields/properties
        return CompanyIds.SequenceEqual(other.CompanyIds);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        // Add all your fields/properties
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
