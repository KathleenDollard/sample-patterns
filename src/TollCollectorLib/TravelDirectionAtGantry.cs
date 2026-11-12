namespace TollCollectorLib;

public enum TravelDirectionAtGantry
{
    // EastOrNorth is not stated, so is zero.

    // This means newly created objects have this default.

    // You can demand a direction in any constructor and
    // set as required for init.

    // Reference types give a warning to do this if NRT is
    // enabled, but you don't get a warning for value types.
    EastOrNorth,
    WestOrSouth
}



