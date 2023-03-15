using System.Globalization;

namespace VVPS.UnitTests
{
    [TestFixture]
    public class TicketReservationTests
    {

        #region ReserveTicketTests

        [Test]
        public void ReserveTicket_ShouldReturnFalse_WhenTicketIsNull()
        {
            // Arrange
            DateTime departureDate = 
                DateTime.ParseExact("23.09.2050", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            // Act
            bool wasSuccessful = TicketReservation.ReserveTicket(null, departureDate);

            // Assert
            Assert.That(wasSuccessful, Is.False);
        }

        [Test]
        public void ReserveTicket_ShouldReturnFalse_WhenReservationInvalid()
        {
            // Arrange
            DateTime departureDate =
                DateTime.ParseExact("03.07.1999", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Ticket ticket = new("CityA", "CityB", false, false);

            // Act
            bool wasSuccessful = TicketReservation.ReserveTicket(ticket, departureDate);

            // Assert
            Assert.That(wasSuccessful, Is.False);
        }

        [Test]
        public void ReserveTicket_ShouldReturnTrue_WhenTicketPresentAndReservationValid()
        {
            // Arrange
            DateTime departureDate =
                DateTime.ParseExact("23.09.2050", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Ticket ticket = new("CityA", "CityB", false, false);

            // Act
            bool wasSuccessful = TicketReservation.ReserveTicket(ticket, departureDate);

            // Assert
            Assert.That(wasSuccessful, Is.True);
        }

        #endregion
    }
}
