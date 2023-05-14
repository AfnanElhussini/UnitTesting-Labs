using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTestLab
{
    public class CarStoreTestsLab
    {
        [TestMethod]
        public void GetAllStoreCars_AddingCar_IsSubSet()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            List <Car> carsAdded = new List<Car>() { car1};

            var carStore = new CarStore(new List<Car>()
            {
           car1, car2, car3

            });

            var cars = carStore.GetAllStoreCars();
            CollectionAssert.IsSubsetOf(carsAdded, cars);

        }


        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_Equivalent()
        {
            // Arrange
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.BMW, 0, DrivingMode.Forward);
            var carStore1 = new CarStore(new List<Car>() { car1, car2 });
            var carStore2 = new CarStore(new List<Car>() { car2, car1 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEquivalent(store1Cars, store2Cars);
        }
    }
}
