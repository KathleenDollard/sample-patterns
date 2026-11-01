using System.Diagnostics.CodeAnalysis;

// Change the namespace to TollCollectorLib.Old and the one in TollGantryReading.cs
// to TollCollectorLib to see the approach I chose

namespace TollCollectorLib.Old;

// The issue of different kinds of vehicles:
// - CarGantryReading uses an instance constructor
// - TaxiGantryReading pretends there is no issue
// - BusGantryReading uses a property to set the vehicle
//      (but results in warning on parameterless constructor)
// - DeliveryTruckGantryReading uses a generic base class to set the vehicle
//      (but results in warning on parameterless constructor)

// None of these are particularly great - see TollGantryReading.cs for a better approach
// This remains in place to show the original issue.

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



