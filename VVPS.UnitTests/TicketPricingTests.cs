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

        private Dictionary<string, double> PricingTable { get; set; }

        private DiscountCard DiscountCard { get; set; }

        #region Setup

        [SetUp]
        public void Setup()
        {
            FromCity = "Sofia";
            ToCity = "Varna";

            PricingTable = new Dictionary<string, double>() { { "Sofia-Varna", 50.0 } };

            DiscountCard = new FamilyDiscountCard(null, "Jane", "Doe");
        }

        #endregion

        #region CalculatePriceFromTimeOfDayTests

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldThrowNullReferenceException_WhenPricingTableIsNull()
        {
            // Arrange
            TicketPricing.PricingTable = null;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            object[] parameters = { FromCity, ToCity, DateTime.Now };

            // Act & Assert
            var exception = Assert.Throws<TargetInvocationException>(
                () => methodInfo?.Invoke(null, parameters)
            );
            Assert.That(exception.InnerException, Is.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldThrowArgumentException_WhenSearchKeyNotPresent()
        {
            // Arrange
            TicketPricing.PricingTable = PricingTable;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            string fromCity = "random";
            string toCity = "random";
            object[] parameters = { fromCity, toCity, DateTime.Now };

            // Act & Assert
            var exception = Assert.Throws<TargetInvocationException>(
                () => methodInfo?.Invoke(null, parameters)
            );
            Assert.That(exception.InnerException, Is.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldReturnBasePrice_WhenLessThenMorningTime()
        {
            // Arrange
            TicketPricing.PricingTable = PricingTable;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            object[] parameters = { FromCity, ToCity, new DateTime(2023, 03, 17, 8, 0, 0) };
            double basePrice = 50.0;
            double tolerance = 0.0001;

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
            TicketPricing.PricingTable = PricingTable;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            object[] parameters = { FromCity, ToCity, new DateTime(2023, 03, 17, 10, 0, 0) };
            double discountedPrice = 47.5;
            double tolerance = 0.0001;

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
            TicketPricing.PricingTable = PricingTable;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            object[] parameters = { FromCity, ToCity, new DateTime(2023, 03, 17, 17, 30, 0) };
            double basePrice = 50.0;
            double tolerance = 0.0001;

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(basePrice).Within(tolerance));
        }

        // test for CalculatePriceFromTimeOfDay_ShouldReturnDiscountedPrice_WhenGreaterThenEveningTime
        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldReturnDiscountedPrice_WhenGreaterThenEveningTime()
        {
            // Arrange
            TicketPricing.PricingTable = PricingTable;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromTimeOfDay",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            object[] parameters = { FromCity, ToCity, new DateTime(2023, 03, 17, 20, 0, 0) };
            double discountedPrice = 47.5;
            double tolerance = 0.0001;

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(discountedPrice).Within(tolerance));
        }

        #endregion

        #region CalculatePriceFromDiscountTests

        [Test]
        public void CalculatePriceFromDiscount_ShouldThrowNullReferenceException_WhenPricingTableIsNull()
        {
            // Arrange
            TicketPricing.PricingTable = null;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromDiscount",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            bool childUnder16Present = false;
            object[] parameters = { FromCity, ToCity, DiscountCard, childUnder16Present };

            // Act & Assert
            var exception = Assert.Throws<TargetInvocationException>(
                () => methodInfo?.Invoke(null, parameters)
            );
            Assert.That(exception.InnerException, Is.InstanceOf<NullReferenceException>());
        }

        [Test]
        public void CalculatePriceFromDiscount_ShouldThrowArgumentException_WhenSearchKeyNotPresent()
        {
            // Arrange
            TicketPricing.PricingTable = PricingTable;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromDiscount",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            string fromCity = "randomText";
            string toCity = "randomText";
            bool childUnder16Present = false;
            object[] parameters = { fromCity, toCity, DiscountCard, childUnder16Present };

            // Act & Assert
            var exception = Assert.Throws<TargetInvocationException>(
                () => methodInfo?.Invoke(null, parameters)
            );
            Assert.That(exception.InnerException, Is.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CalculatePriceFromDiscount_ShouldReturnDiscountedPrice_WhenDiscountCardPresent()
        {
            // Arrange
            TicketPricing.PricingTable = PricingTable;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromDiscount",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            bool childUnder16Present = false;
            object[] parameters = { FromCity, ToCity, DiscountCard, childUnder16Present };
            double discountedPrice = 45.0;
            double tolerance = 0.0001;

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
            TicketPricing.PricingTable = PricingTable;
            MethodInfo? methodInfo = typeof(TicketPricing).GetMethod(
                "CalculatePriceFromDiscount",
                BindingFlags.NonPublic | BindingFlags.Static
            );
            bool childUnder16Present = false;
            object?[] parameters = { FromCity, ToCity, null, childUnder16Present };
            double tolerance = 0.0001;
            double basePrice = 50.0;

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
            TicketPricing.PricingTable = PricingTable;
            Ticket ticket = new(null, FromCity, ToCity, false, false);
            double discountedPrice = 47.5;
            double tolerance = 0.0001;

            // Act
            double resultPrice = TicketPricing.CalculateTotalPrice(ticket);

            // Assert
            Assert.That(resultPrice, Is.GreaterThanOrEqualTo(discountedPrice).Within(tolerance));
        }

        [Test]
        public void CalculateTotalPrice_ShouldReturnHigherDiscountedPrice_WhenDiscountCardPresent()
        {
            // Arrange
            TicketPricing.PricingTable = PricingTable;
            Ticket ticket = new(null, FromCity, ToCity, true, false);
            ticket.UsedDiscountCard = DiscountCard;
            double discountedPrice = 90.0;
            double tolerance = 0.0001;

            // Act
            double resultPrice = TicketPricing.CalculateTotalPrice(ticket);

            // Assert
            Assert.That(resultPrice, Is.LessThanOrEqualTo(discountedPrice).Within(tolerance));
        }

        #endregion
    }
}
