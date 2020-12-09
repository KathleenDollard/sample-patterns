namespace CommercialRegistration
{
    public record DeliveryTruck(int GrossWeightClass);
}

namespace ConsumerVehicleRegistration
{
    public record Car(int Passengers);
}

namespace GreenRegistration
{
    public record Cycle(int Riders, int Wheels);
}

namespace LiveryRegistration
{
    public record Taxi(int Fares);

    public record Bus(int Capacity, int Riders);
}
