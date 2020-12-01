namespace GreenRegistration
{
    public readonly struct Cycle
    {
        public Cycle(int riders, int wheels)
        {
            Riders = riders;
            Wheels = wheels;
        }

        public void Deconstruct(out int riders, out int wheels) =>
                (riders, wheels) = (Riders, Wheels);

        public int Riders { get; }
        public int Wheels { get; }
    }
}
