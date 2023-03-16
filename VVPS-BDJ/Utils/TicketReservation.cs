﻿using VVPS_BDJ.Models;

namespace VVPS_BDJ.Utils
{
    public static class TicketReservation
    {
        public static Reservation ReserveTickets(IEnumerable<Ticket> tickets, DateTime reservationDate)
        {
            if (tickets == null)
                throw new ArgumentNullException(nameof(tickets));

            bool includesInvalidReservations = tickets.Any(ticket => ticket.DepartureDate <= reservationDate);

            if (includesInvalidReservations)
                throw new ArgumentException("Found expired tickets passed as an argument!");
            
            Reservation reservation = new(null, tickets, reservationDate);

            return reservation;
        }

        // TODO: Store ticket reservations
        // TODO: View ticket reservations
        // TODO: Change ticket reservations
        // TODO: Cancel ticket reservations
    }
}
