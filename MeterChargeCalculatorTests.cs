using System;
using NUnit.Framework;

namespace MeterCharge
{
    [TestFixture]
    public class MeterChargeCalculatorTests
    {
        [Test]
        public void GetCharge_Electricity_ReturnsConsumptionNormal()
        {
            // Arrange
            int consumption = 97;
            DateTimeProvider.Set(() => new DateTime(2022, 6, 9, 10, 30, 30));

            // Act
            int charge = ElectricityCalculator.GetCharge(consumption);

            // Assert
            Assert.AreEqual(388, charge);
        }
        [Test]
        public void GetCharge_Electricity_ReturnsConsumptionHalf()
        {
            // Arrange
            int consumption = 50;
            DateTimeProvider.Set(() => new DateTime(2022, 6, 9, 23, 30, 30));

            // Act
            int charge = ElectricityCalculator.GetCharge(consumption);

            // Assert
            Assert.AreEqual(100, charge);
        }
        [Test]
        public void GetCharge_Heating_ReturnsConsumption()
        {
            // Arrange
            int consumption = 55;

            // Act
            int charge = HeatingCalculator.GetCharge(consumption);

            // Assert
            Assert.AreEqual(275, charge);
        }
        [Test]
        public void GetCharge_Water_ReturnsConsumption()
        {
            // Arrange
            int consumption = 98;

            // Act
            int charge = WaterCalculator.GetCharge(consumption);

            // Assert
            Assert.AreEqual(294, charge);
        }
    }
}