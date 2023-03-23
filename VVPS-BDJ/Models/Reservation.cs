namespace VVPS_BDJ.Models
{
    public class Reservation
    {
        public int? ReservationId { get; private set; }
        public IEnumerable<Ticket> ReservedTickets { get; set; }
        public DateTime ReservedOn { get; set; }

        public int UserId { get; set; }

        public bool Canceled { get; set; }

        public Reservation()
        {
            ReservedTickets = Enumerable.Empty<Ticket>();
        }

        public Reservation(
            int? reservationId,
            IEnumerable<Ticket> reservedTickets,
            DateTime reservedOn,
            int userId
        )
        {
            ReservationId = reservationId;
            ReservedTickets = reservedTickets;
            ReservedOn = reservedOn;
            Canceled = false;
            UserId = userId;
        }
    }
}
