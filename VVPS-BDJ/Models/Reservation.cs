namespace VVPS_BDJ.Models
{
    public class Reservation
    {
        public int? ReservationId { get; private set; }
        public IEnumerable<Ticket> ReservedTickets { get; set; }
        public DateTime ReservedOn { get; set; }

        public bool Canceled { get; set; }

        public Reservation() {}

        public Reservation(int? reservationId, IEnumerable<Ticket> reservedTickets, DateTime reservedOn)
        {
            ReservationId = reservationId;
            ReservedTickets = reservedTickets;
            ReservedOn = reservedOn;
            Canceled = false;
        }
    }
}
