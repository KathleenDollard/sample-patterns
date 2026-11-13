using Narnia.VehicleRegistrations.CommercialRegistration;
using Narnia.VehicleRegistrations.ConsumerVehicleRegistration;
using Narnia.VehicleRegistrations.LiveryRegistration;
using System.Diagnostics.CodeAnalysis;

namespace Narnia.RealTimeSystem;

public abstract record class TollGantryReading
{
    // If you use a ctor, update these setter scope
    public required DateTime TimeOfPassing { get; init; }
    public required TravelDirectionAtGantry Direction { get; init; }
    public abstract object Vehicle { get; }
}

public record class CarGantryReading : TollGantryReading
{
    [SetsRequiredMembers]
    public CarGantryReading(Car car,
                            DateTime timeOfPassing,
                            TravelDirectionAtGantry direction,
                            int passengers)
    {
        Car = car;
        Passengers = passengers;
        TimeOfPassing = timeOfPassing;
        Direction = direction;
    }

    public required Car Car { get; init; }
    public required int Passengers { get; init; }

    public override object Vehicle
    {
        get => Car;
    }
}

public record class TaxiGantryReading : TollGantryReading
{
    public required Taxi Taxi { get; init; }
    public required int Fares { get; init; }

    public override object Vehicle
    {
        get => Taxi;
    }
}

public record class BusGantryReading : TollGantryReading
{
    public required Bus Bus { get; init; }
    public required int Riders { get; init; }
    public override object Vehicle
    {
        get => Bus;
    }

}

public record class DeliveryTruckGantryReading : TollGantryReading
{
    public required DeliveryTruck DeliveryTruck { get; init; }
    public required int GrossWeightClass { get; init; }
    public override object Vehicle
    {
        get => DeliveryTruck;
    }
}



