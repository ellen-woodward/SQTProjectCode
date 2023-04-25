using Moq;
using NUnit.Framework;
using SQTCode;

namespace Test
{

    [TestFixture]
    public class Program
    {
        [TestCase(25, "rural", 0, 5)]
        [TestCase(40, "rural", 0, 2.5)]
        [TestCase(17, "rural", 0, 0)]
        [TestCase(25, "urban", 0, 6)]
        [TestCase(51, "urban", 0.5, 2.5)]
        [TestCase(17, "urban", 0, 0)]
        [TestCase(25, "town", 0, 0)]

        public void GetPremium_Age_Location(int age, string location, double discount, double result)
        {
            //Arrange
            var mockDiscountService = new Mock<DiscountService>();
            mockDiscountService.Setup(x => x.GetDiscount()).Returns(discount);
            var insuranceService = new InsuranceService(mockDiscountService.Object);
            //Act
            double premium = insuranceService.CalculatePremium(age, location);
            //Assert
            Assert.That(premium, Is.EqualTo(result));
        }

    }

}