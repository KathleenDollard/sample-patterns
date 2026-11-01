using System.Diagnostics.CodeAnalysis;

namespace TollCollectorLib;

// The issue of different kinds of vehicles:
// - CarGantryReading uses an instance constructor
// - TaxiGantryReading pretends there is no issue
// - BusGantryReading uses a property to set the vehicle
// - DeliveryTruckGantryReading uses a generic base class to set the vehicle

// All but the taxi approach are valid.
// Build in guardrails where you can.

// The car approach doesn't allow object initialization.
// It requires the constructor be called.

// The DeliveryTruck/generic base is very helpful when you want
// to use or constrain the type, which is often.
// ** See TollGantryReadingNew.cs **

// Constructors can be used with the generic base

// Pick an approach and prefer it for consistency.

public abstract record class TollGantryReading
{
    protected TollGantryReading() { }

    [SetsRequiredMembers]
    protected TollGantryReading(object vehicle, DateTime timeOfPassing, TravelDirectionAtGantry direction)
    {
        Vehicle = vehicle;
        TimeOfPassing = timeOfPassing;
        Direction = direction;
    }

    public object Vehicle { get; init; }
    public required DateTime TimeOfPassing { get; init; }
    public required TravelDirectionAtGantry Direction { get; init; }
}

public record class CarGantryReading : TollGantryReading
{
    [SetsRequiredMembers]
    public CarGantryReading(Car car,
                            DateTime timeOfPassing,
                            TravelDirectionAtGantry direction,
                            int passengers)
       : base(car, timeOfPassing, direction)
    {
        Passengers = passengers;
    }
    public int Passengers { get; }

}

public record class TaxiGantryReading : TollGantryReading
{
    public required int Fares { get; init; }
}

public record class BusGantryReading : TollGantryReading
{
    public required Bus Bus
    {
        get;
        init
        {
            field = value;
            Vehicle = value;
        }
    }

    public required int Riders { get; init; }
}

public record class TollGantryReading<T> : TollGantryReading
    where T : class
{
    public new required T Vehicle
    {
        get; init
        {
            field = value;
            base.Vehicle = value;
        }
    }
}

public record class DeliveryTruckGantryReading : TollGantryReading<DeliveryTruck>
{
    public required int GrossWeightClass { get; init; }
}



