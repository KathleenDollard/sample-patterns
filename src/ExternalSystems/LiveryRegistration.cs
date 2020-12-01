namespace LiveryRegistration
{
    public class Taxi
    {
        public int Fares { get; set; }
    }

    public class Bus
    {
        public int Capacity { get; set; }
        public int Riders { get; set; }

        public void Deconstruct(out int capacity, out int riders)
        => (capacity, riders) = (Capacity, Riders);
    }
}
