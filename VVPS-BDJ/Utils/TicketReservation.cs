using VVPS_BDJ.Models;

namespace VVPS_BDJ.Utils;

public static class TicketReservation
{
    public static Reservation ReserveTickets(
        IEnumerable<Ticket> tickets,
        DateTime reservationDate,
        int userId
    )
    {
        if (tickets == null)
            throw new ArgumentNullException(nameof(tickets));

        bool includesInvalidReservations = tickets.Any(
            ticket => ticket.DepartureDate < reservationDate
        );

        if (includesInvalidReservations)
            throw new ArgumentException("Found expired tickets passed as an argument!");

        Reservation reservation = new(null, tickets, reservationDate, userId);

        return reservation;
    }
}
