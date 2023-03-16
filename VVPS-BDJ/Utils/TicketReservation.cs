using VVPS_BDJ.Models;

namespace VVPS_BDJ.Utils
{
    public static class TicketReservation
    {
        public static bool ReserveTickets(IEnumerable<Ticket> tickets, DateTime reservationDate)
        {
            if (tickets == null) return false;
            bool includesInvalidReservations = tickets.Any(ticket => ticket.DepartureDate <= reservationDate);
            Reservation reservation = new(null, tickets, reservationDate);

            // TODO: Store tickets in DB
            return true;
        }

        // TODO: Store ticket reservations
        // TODO: View ticket reservations
        // TODO: Change ticket reservations
        // TODO: Cancel ticket reservations
    }
}
