using System;

namespace VVPS
{
    public static class TicketReservation
    {
        // TODO: Add train Timetable - {From-To} + Departure time
        public static bool ReserveTicket(Ticket ticket, DateTime departureDate)
        {
            // TODO: add check for valid departure time
            // TODO: compare time portion of departureDate and Timetable departureDate
            DateTime reservedDate = DateTime.Now;
            bool isTicketNull = ticket == null;
            bool isReservationInvalid = departureDate <= reservedDate;
            
            if(isTicketNull || isReservationInvalid) return false;

            ticket.ReservedOn = reservedDate;
            ticket.DepartureDate = departureDate;

            return true;
        }

        // TODO: Store ticket reservations
        // TODO: View ticket reservations
        // TODO: Change ticket reservations
        // TODO: Cancel ticker reservations
    }
}
