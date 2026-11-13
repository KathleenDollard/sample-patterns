using Narnia.VehicleRegistrations.CommercialRegistration;
using Narnia.VehicleRegistrations.ConsumerVehicleRegistration;
using Narnia.VehicleRegistrations.LiveryRegistration;

namespace TollTests
{
    public class ExternalSystemTests
    {
        [Fact]
        public void TaxiHasValueEquality()
        {
            var taxi1 = new Taxi();
            var taxi2 = new Taxi();
            Assert.True(taxi1.Equals(taxi2));
        }

        [Fact]
        public void BusHasValueEquality()
        {
            var bus1 = new Bus(50);
            var bus2 = new Bus(50);
            Assert.True(bus1.Equals(bus2));
        }

        [Fact]
        public void RideshareHasValueEquality()
        {
            var rideshare1 = new Rideshare([1, 2]);
            var rideshare2 = new Rideshare([1, 2]);
            Assert.True(rideshare1.Equals(rideshare2));
        }

        [Fact]
        public void CarHasValueEquality()
        {
            var car1 = new Car();
            var car2 = new Car();
            Assert.True(car1.Equals(car2));
        }

        [Fact]
        public void DeliveryTruckHasValueEquality()
        {
            var truck1 = new DeliveryTruck(1);
            var truck2 = new DeliveryTruck(1);
            Assert.True(truck1.Equals(truck2));
        }
    }
}
