using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppTests
{
    [TestClass]
    public class CarStoreTests
    {


        #region Collection Assert

        [TestMethod]
        public void GetAllStoreCars_AddingCars_Contains()
        {
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();
            var carStore = new CarStore(new List<Car> { car1, car2, car3 });

            var cars = carStore.GetAllStoreCars();

            CollectionAssert.Contains(cars, car1);
        }

        [TestMethod]
        public void AddCars_AddingCars_IsSubset()
        {
            Car car1 = new Car();
            Car car2 = new Car();
            var carStore = new CarStore(new List<Car> { car1, car2 });
            Car car3 = new Car();
            Car car4 = new Car();
            var newCars = new List<Car>() { car3, car4 };

            carStore.AddCars(newCars);

            CollectionAssert.IsSubsetOf(newCars, carStore.Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_Equal()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var car3 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car4 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore2 = new CarStore(new List<Car> { car3, car4 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEqual(store1Cars, store2Cars);
        }


        [TestMethod]
        public void GetAllStoreCars_EqualCarsDifferentOrder_NotEqual()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var car3 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car4 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore2 = new CarStore(new List<Car> { car4, car3 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreNotEqual(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_SameCarsDifferentOrder_NotEqual()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });
            var carStore2 = new CarStore(new List<Car> { car2, car1 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreNotEqual(store1Cars, store2Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_SameCarsDifferentOrder_Equivalent()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });
            var carStore2 = new CarStore(new List<Car> { car2, car1 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEquivalent(store1Cars, store2Cars);
        }


        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_NotEquivalent()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var car3 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car4 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore2 = new CarStore(new List<Car> { car3, car4 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreNotEquivalent(store1Cars, store2Cars);
        }


        [TestMethod]
        public void GetAllStoreCars_SameCarsRepeated_Unique()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var car3 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore1 = new CarStore(new List<Car> { car1, car2, car3 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();

            // Assert
            CollectionAssert.AllItemsAreUnique(store1Cars);
        }
        #endregion

        #region Assert
        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_NotEqualLists()
        {
            // Arrange
            var car1 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car2 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var car3 = new Car(CarType.Audi, 10, DrivingMode.Forward);
            var car4 = new Car(CarType.Honda, 0, DrivingMode.Stopped);
            var carStore2 = new CarStore(new List<Car> { car3, car4 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            Assert.AreNotEqual(store1Cars, store2Cars);
        } 
        #endregion
    }
}
