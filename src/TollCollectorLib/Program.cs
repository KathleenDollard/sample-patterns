
var car = new Car(2);
var taxi = new Taxi(1);
var bus = new Bus(50, 3);
var deliveryTruck = new DeliveryTruck(1);
Console.WriteLine($"Car toll: {TollCalculator2024.GetBillAmount(car, DateTime.Now, true)}");
Console.WriteLine($"Taxi toll: {TollCalculator2024.GetBillAmount(taxi, DateTime.Now, true)}");
Console.WriteLine($"Bus toll: {TollCalculator2024.GetBillAmount(bus, DateTime.Now, true)}");
Demo(car); // This is just to have the Demo method highlighted correctly

void Demo(object vehicle)
{
    var taxi = vehicle as Taxi;
    if (taxi != null)
    {
        // interesting stuff done here
    }

    bool isBus;
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

}

