using System.Reflection;

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

            TicketPricing.PricingTable = new Dictionary<string, double>()
            {
                {"Sofia-Varna", 50.0 }
            };

            DiscountCard = new FamilyDiscountCard("Jane", "Doe");
        }

        #endregion

        #region CalculatePriceFromTimeOfDayTests

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldThrowArgumentException_WhenSearchKeyNotPresent()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing)
                .GetMethod("CalculatePriceFromTimeOfDay", BindingFlags.NonPublic | BindingFlags.Static);
            string fromCity = "random";
            string toCity = "random";
            string[] parameters = { fromCity, toCity };

            // Act & Assert
            var exception = Assert.Throws<TargetInvocationException>(() => methodInfo?.Invoke(null, parameters));
            Assert.That(exception.InnerException, Is.InstanceOf<ArgumentException>());
        }


        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldReturnDiscontedPrice_WhenInsideTimeFrame()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing)
                .GetMethod("CalculatePriceFromTimeOfDay", BindingFlags.NonPublic | BindingFlags.Static);
            string[] parameters = { FromCity, ToCity };
            double discountedPrice = 47.5;
            double tolerance = 0.0001;

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(discountedPrice).Within(tolerance));
        }

        [Test]
        public void CalculatePriceFromTimeOfDay_ShouldReturnBasePrice_WhenOutsideTimeFrame()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing)
                .GetMethod("CalculatePriceFromTimeOfDay", BindingFlags.NonPublic | BindingFlags.Static);
            string[] parameters = { FromCity, ToCity };
            double basePrice = 50.0;
            double tolerance = 0.0001;

            // Act
            object? result = methodInfo?.Invoke(null, parameters);
            double? resultPrice = (double?)result;

            // Assert
            Assert.That(resultPrice, Is.EqualTo(basePrice).Within(tolerance));
        }

        #endregion

        #region CalculatePriceFromDiscountTests

        [Test]
        public void CalculatePriceFromDiscount_ShouldThrowArgumentException_WhenSearchKeyNotPresent()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing)
                .GetMethod("CalculatePriceFromDiscount", BindingFlags.NonPublic | BindingFlags.Static);
            string fromCity = "randomText";
            string toCity = "randomText";
            bool childUnder16Present = false;
            object[] parameters = { fromCity, toCity, DiscountCard, childUnder16Present };

            // Act & Assert
            var exception = Assert.Throws<TargetInvocationException>(() => methodInfo?.Invoke(null, parameters));
            Assert.That(exception.InnerException, Is.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CalculatePriceFromDiscount_ShouldReturnDiscontedPrice_WhenDiscontCardPresent()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing)
                .GetMethod("CalculatePriceFromDiscount", BindingFlags.NonPublic | BindingFlags.Static);
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
        public void CalculatePriceFromDiscount_ShouldReturnBasePrice_WhenDiscontCardIsNull()
        {
            // Arrange
            MethodInfo? methodInfo = typeof(TicketPricing)
                .GetMethod("CalculatePriceFromDiscount", BindingFlags.NonPublic | BindingFlags.Static);
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
        public void CalculateTotalPrice_ShouldReturnLowerDiscontedPrice_WhenDiscontCardIsNull()
        {
            // Arrange
            Ticket ticket = new(FromCity, ToCity, false, false);
            double discountedPrice = 47.5;
            double tolerance = 0.0001;

            // Act
            double resultPrice = TicketPricing.CalculateTotalPrice(ticket);

            // Assert
            Assert.That(resultPrice, Is.GreaterThanOrEqualTo(discountedPrice).Within(tolerance));
        }


        [Test]
        public void CalculateTotalPrice_ShouldReturnHigherDiscontedPrice_WhenDiscontCardPresent()
        {
            // Arrange
            Ticket ticket = new(FromCity, ToCity, true, false);
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