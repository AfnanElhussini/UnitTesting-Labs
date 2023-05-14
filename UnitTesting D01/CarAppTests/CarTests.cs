using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarAppTests
{
    [TestClass]
    public class CarTests
    {
        #region Initialize
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            context.WriteLine("class init");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {

        }

        [TestInitialize]
        public void UnitTestInitialize()
        {
            TestContext.WriteLine("test init");
        }

        [TestCleanup]
        public void UnitTestCleanup()
        {
            TestContext.WriteLine("test cleanup");
        }

        public CarTests()
        {
            Console.WriteLine("CTOR");
        }

        #endregion

        #region Assert
        // Naming convention: "MethodUnderTest_StateUnderTest_ExpectedOutput"
        [Owner("Mohamed")]
        [TestMethod]
        public void TimeToCoverProvidedDistance_Distance100Velocity25_Time4()
        {
            // Arrange
            Car car = new Car();
            car.Velocity = 25;
            double distance = 100;
            double expectedResult = 4;

            // Act
            double result = car.TimeToCoverProvidedDistance(distance);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Accelerate_ToyotaVelocity10_Velocity20()
        {
            // Arrange
            Car car = new Car();
            car.Type = CarType.Toyota;
            car.Velocity = 10;
            double expectedResult = 20;

            // Act
            car.Accelerate();

            // Assert
            Assert.AreEqual(expectedResult, car.Velocity);
        }

        [Owner("Mohamed")]
        [Priority(1)]
        [TestCategory("Equivalence")] 
        [TestMethod]

        public void GetMyCar_ExistingInstance_SameCar()
        {
            // Arrange
            var car = new Car();

            // Act
            var result = car.GetMyCar();

            // Assert
            Assert.AreSame(car, result);
        }

        [Owner("Islam")]
        [Priority(2)]
        [TestCategory("Equality")]
        [TestMethod]
        public void TwoCar_SameState_Equal()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            Car car2 = new Car(CarType.Toyota, 0, DrivingMode.Forward);

            // Act

            // Assert
            Assert.AreEqual(car2, car1);
        }

        [Priority(2)]
        [TestCategory("Equivalence")]
        [TestMethod]
        public void TwoCar_SameState_NotSame()
        {
            // Arrange
            Car car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            Car car2 = new Car(CarType.Toyota, 0, DrivingMode.Forward);

            // Act

            // Assert
            Assert.AreNotSame(car2, car1);
        }

        [Ignore]
        [TestMethod]
        public void GetMyCar_ExistingInstance_IsTypeCar()
        {
            var car = new Car();

            var result = car.GetMyCar();

            Assert.IsInstanceOfType(result, typeof(Car));
        }

        [TestMethod]
        public void GetMyCar_ExistingInstance_NotNull()
        {
            var car = new Car();

            var result = car.GetMyCar();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IsStopped_Velocity25_False()
        {
            // Arrange
            var car = new Car();
            car.Velocity = 25;

            // Act
            var result = car.IsStopped();

            // Assert
            Assert.IsFalse(result);
        }
        #endregion

        #region String Assert
        [TestMethod]
        public void GetDirection_Forward_PrintForward()
        {
            // Arrange
            var car = new Car();
            car.DrivingMode = DrivingMode.Forward;

            // Act
            var result = car.GetDirection();

            // Assert
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("^Forward$"));
        }

        #endregion

        #region Exception
        [TestMethod]
        public void Accelerate_Honda_ThrowException()
        {
            var car = new Car();
            car.Type = CarType.Honda;


            //Assert.ThrowsException<NotImplementedException>(car.Accelerate);
            Assert.ThrowsException<NotImplementedException>(() => car.Accelerate());
        }

        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void Accelerate_Honda_ThrowNotImplementedException()
        {
            var car = new Car();
            car.Type = CarType.Honda;

            car.Accelerate();
        }
        #endregion
    }
}
