using VVPS_BDJ.Models;
using VVPS_BDJ.Utils;

namespace VVPS.UnitTests
{
    [TestFixture]
    public class TicketReservationTests
    {
        #region ReserveTicketTests

        [Test]
        public void ReserveTicket_ShouldThrowArgumentNullException_WhenTicketsAreNull()
        {
            // Arrange
            DateTime reservationDate = new(2025, 9, 23);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(
                () => TicketReservation.ReserveTickets(null, reservationDate, 0)
            );
        }

        [Test]
        public void ReserveTicket_ShouldThrowArgumentException_WhenTicketsAreExpired()
        {
            // Arrange
            Ticket[] tickets = new Ticket[]
            {
                new Ticket(null, "Sofia", "Varna", false, false)
                {
                    DepartureDate = new DateTime(2020, 2, 18)
                }
            };

            DateTime reservationDate = new(2050, 9, 23);

            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => TicketReservation.ReserveTickets(tickets, reservationDate, 0)
            );
        }

        [Test]
        public void ReserveTicket_ShouldReturnReservation_WhenTicketsAreValid()
        {
            // Arrange
            Ticket[] tickets = new Ticket[]
            {
                new Ticket(null, "Sofia", "Varna", false, false)
                {
                    DepartureDate = new DateTime(2020, 2, 18)
                }
            };

            DateTime reservationDate = new(2019, 9, 23);

            // Act
            var reservation = TicketReservation.ReserveTickets(tickets, reservationDate, 0);

            // Assert
            Assert.That(reservation, Is.Not.Null);
            Assert.That(reservation.ReservedOn, Is.EqualTo(reservationDate));
            Assert.That(reservation.ReservedTickets, Is.SameAs(tickets));
        }

        #endregion
    }
}
