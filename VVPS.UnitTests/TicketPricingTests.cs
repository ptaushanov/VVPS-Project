using System.Reflection;
using VVPS_BDJ.Models;
using VVPS_BDJ.Utils;

namespace VVPS.UnitTests
{
    [TestFixture]
    public class TicketPricingTests
    {
        private string FromCity { get; set; }
        private string ToCity { get; set; }

        private DiscountCard DiscountCard { get; set; }

        #region Setup

        [SetUp]
        public void Setup()
        {
            FromCity = "Sofia";
            ToCity = "Varna";

            DiscountCard = new FamilyDiscountCard();
        }

        #endregion

        #region CalculatePriceFromTimeOfDayTests

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldReturnBasePrice_WhenLessThenMorningTime()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );

            double basePrice = 50.0;
            double tolerance = 0.0001;
            object[] parameters = { basePrice, new DateTime(2023, 03, 17, 8, 0, 0) };

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(basePrice).Within(tolerance));
        }

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldReturnDiscountedPrice_WhenBetweenMorningAndAfternoonTime()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            double basePrice = 50.0;
            double discountedPrice = 47.5;
            double tolerance = 0.0001;

            object[] parameters = { basePrice, new DateTime(2023, 03, 17, 10, 0, 0) };

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(discountedPrice).Within(tolerance));
        }

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldReturnBasePrice_WhenBetweenAfternoonAndEveningTime()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );

            double basePrice = 50.0;
            double tolerance = 0.0001;
            object[] parameters = { basePrice, new DateTime(2023, 03, 17, 17, 30, 0) };

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(basePrice).Within(tolerance));
        }

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldReturnDiscountedPrice_WhenGreaterThenEveningTime()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            double basePrice = 50.0;
            double discountedPrice = 47.5;
            double tolerance = 0.0001;

            object[] parameters = { basePrice, new DateTime(2023, 03, 17, 20, 0, 0) };

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(discountedPrice).Within(tolerance));
        }

        #endregion

        #region CalculatePriceFromDiscountTests

        [Test]
        public void CalculatePriceFromDiscount_ShouldReturnDiscountedPrice_WhenDiscountCardPresent()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromDiscount",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            bool childUnder16Present = false;
            double basePrice = 50.0;
            double discountedPrice = 45.0;
            double tolerance = 0.0001;
            object[] parameters = { basePrice, DiscountCard, childUnder16Present };
            
            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(discountedPrice).Within(tolerance));
        }

        [Test]
        public void CalculatePriceFromDiscount_ShouldReturnBasePrice_WhenDiscountCardIsNull()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromDiscount",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            bool childUnder16Present = false;
            double tolerance = 0.0001;
            double basePrice = 50.0;
            object?[] parameters = { basePrice, null, childUnder16Present };

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(basePrice).Within(tolerance));
        }

        #endregion

        #region CalculateTotalPriceTests

        [Test]
        public void CalculateTotalPrice_ShouldReturnLowerDiscountedPrice_WhenDiscountCardIsNull()
        {
            // Arrange
            Ticket ticket = new(null, FromCity, ToCity, false, false);
            double basePrice = 50.0;
            double discountedPrice = 47.5;
            double tolerance = 0.0001;

            // Act
            double resultPrice = TicketPricing.CalculateTotalPrice(ticket, basePrice);

            // Assert
            Assert.That(resultPrice, Is.GreaterThanOrEqualTo(discountedPrice).Within(tolerance));
        }

        [Test]
        public void CalculateTotalPrice_ShouldReturnHigherDiscountedPrice_WhenDiscountCardPresent()
        {
            // Arrange
            Ticket ticket = new(null, FromCity, ToCity, true, false);
            ticket.UsedDiscountCard = DiscountCard;

            double basePrice = 50.0;
            double discountedPrice = 90.0;
            double tolerance = 0.0001;

            // Act
            double resultPrice = TicketPricing.CalculateTotalPrice(ticket, basePrice);

            // Assert
            Assert.That(resultPrice, Is.LessThanOrEqualTo(discountedPrice).Within(tolerance));
        }

        #endregion
    }
}
