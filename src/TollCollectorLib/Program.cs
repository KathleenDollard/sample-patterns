
var carReading = new CarGantryReading(new Car(),
                                      DateTime.Now,
                                      TravelDirectionAtGantry.WestOrSouth,
                                      2);
var taxiReading = new TaxiGantryReading
{
    Taxi = new Taxi(),
    Fares = 1,
    TimeOfPassing = DateTime.Now,
    Direction = TravelDirectionAtGantry.WestOrSouth
};
var busReading = new BusGantryReading
{
    Bus = new Bus(50),
    Riders = 3,
    TimeOfPassing = DateTime.Now,
    Direction = TravelDirectionAtGantry.WestOrSouth
};
var deliveryTruckReading = new DeliveryTruckGantryReading
{
    DeliveryTruck = new DeliveryTruck(1),
    GrossWeightClass = 1,
    TimeOfPassing = DateTime.Now,
    Direction = TravelDirectionAtGantry.WestOrSouth
};
Console.WriteLine($"Car toll: {TollCalculator.GetBillAmount(carReading)}");
Console.WriteLine($"Taxi toll: {TollCalculator.GetBillAmount(taxiReading)}");
Console.WriteLine($"Bus toll: {TollCalculator.GetBillAmount(busReading)}");
Console.WriteLine($"Delivery Truck toll: {TollCalculator.GetBillAmount(deliveryTruckReading)}");
Demo(carReading); // This is just to have the Demo method highlighted correctly

void Demo(object vehicle)
{
    var taxi = vehicle as Taxi;
    if (taxi != null)
    {
        // interesting stuff done here
    }

    bool isBus = false;
    var isCar = false;
    switch (vehicle)
    {
        case Bus b:
            isBus = true;
            break;
        case Car c:
            isCar = true;
            break;
    }
    Console.WriteLine($"Is bus: {isBus}, is car: {isCar}");
}

