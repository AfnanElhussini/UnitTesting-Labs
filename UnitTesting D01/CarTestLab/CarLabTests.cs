using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarTestLab
{
    [TestClass]
    public class CarLabTests
    {   /*------------------------------ASSERT----------------------------------------------*/
        #region Assert Class First Method 
        [TestMethod]
        public void TimeToCoverProvidedDistance_Distance100Vilocity25_Time4()
        {
            //Arrange > Prepering Objects
            Car car = new Car(CarType.Audi,25,DrivingMode.Forward);
            double povidedDistance = 100;
            double expectedResult = 4;

            //ACT
            double ActualResult = car.TimeToCoverProvidedDistance(povidedDistance);

            //Assert
            Assert.AreEqual(expectedResult, ActualResult);
        }
        #endregion

        #region Assert Class Second Method (Are Equal)
        [TestMethod]
        public void TwoCar_EqualStates_EqualCars()
        {
            //Arrange 
            // car is refrence type So > Failed  To Pass it we override Equals 
            Car car1 = new Car(CarType.Audi, 20, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi,20, DrivingMode.Forward);

            //Act 

            //Assert
            Assert.AreEqual(car1, car2);

        }
        #endregion

        #region Are Same Check Refrances
        [TestMethod]
        public void TwoCar_DiffrentInstanses_SameState()
        {
            Car car1 = new Car(CarType.Audi, 20, DrivingMode.Forward);
            Car actualCar = car1.GetMyCar();

            Assert.AreSame(car1, actualCar);
        }
        #endregion

        #region Are Not Same
        [TestMethod]
        public void TwoCar_DifferentInstancesSameStates_NotSameCars()
        {
            //Arrange 
            // car is refrence type So > Failed  To Pass it we override Equals 
            Car car1 = new Car(CarType.Audi, 20, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 20, DrivingMode.Forward);

            //Act 

            //Assert
            Assert.AreNotSame(car1, car2);

        }
        #endregion

        #region Accelerate

        [TestMethod]
        public void Accelerate_ToyotaIntialVolicty50_Violcity60()
        {
            var car = new Car(CarType.Toyota, 50, DrivingMode.Forward);
            var expectedViolcity = 60;
            car.Accelerate();
            var actualVilocity = car.Velocity;

            Assert.IsTrue(expectedViolcity == actualVilocity);

        }


        #endregion

        #region IS Stopped?
        [TestMethod]
        public void IsStopped_Velocity0_True()
        {
            var car = new Car(CarType.Audi, 0, DrivingMode.Forward);
            var actual = car.IsStopped();
            Assert.IsTrue(actual);
        }
        #endregion

        /*-------------------------------String Assert-----------------------------------*/
        #region StringAssert
        [TestMethod]
        public void GetDirection_Forward_PrintForward()
        {
            var car = new Car();
            car.DrivingMode = DrivingMode.Forward;
            var expected = "Forward";

            var actualDirection = car.GetDirection();
            actualDirection.Replace(actualDirection, expected);

            StringAssert.Matches(actualDirection, new System.Text.RegularExpressions.Regex(expected));

        }




        [TestMethod]
        public void GetDirection_ContainsExpectedValue_True()
        {
            // arrange
            var car = new Car();
            car.DrivingMode = DrivingMode.Forward;
            var expected = "For";

            // act
            var actualDirection = car.GetDirection();

            // assert
            StringAssert.Contains(actualDirection, expected);
        }
        #endregion




        /*------------------------------Collection---------------------------------------*/

        #region Collections
        [TestMethod]
        public void GetAllStoreCars_AddingCar_IsSubSet()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            List<Car> carsAdded = new List<Car>() { car1 };

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
        #endregion
    }
}
