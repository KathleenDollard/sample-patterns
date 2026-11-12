namespace TollTests
{
    public class ExternalSystemTests
    {
        [Fact]
        public void TaxiHasValueEquality()
        {
            var taxi1 = new LiveryRegistration.Taxi();
            var taxi2 = new LiveryRegistration.Taxi();
            Assert.True(taxi1.Equals(taxi2));
        }

        [Fact]
        public void BusHasValueEquality()
        {
            var bus1 = new LiveryRegistration.Bus(50);
            var bus2 = new LiveryRegistration.Bus(50);
            Assert.True(bus1.Equals(bus2));
        }

        [Fact]
        public void RideshareHasValueEquality()
        {
            var rideshare1 = new LiveryRegistration.Rideshare([1, 2]);
            var rideshare2 = new LiveryRegistration.Rideshare([1, 2]);
            Assert.True(rideshare1.Equals(rideshare2));
        }

        [Fact]
        public void CarHasValueEquality()
        {
            var car1 = new ConsumerVehicleRegistration.Car();
            var car2 = new ConsumerVehicleRegistration.Car();
            Assert.True(car1.Equals(car2));
        }

        [Fact]
        public void DeliveryTruckHasValueEquality()
        {
            var truck1 = new CommercialRegistration.DeliveryTruck(1);
            var truck2 = new CommercialRegistration.DeliveryTruck(1);
            Assert.True(truck1.Equals(truck2));
        }
    }
}
