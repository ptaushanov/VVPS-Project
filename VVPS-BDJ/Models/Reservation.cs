namespace VVPS_BDJ.Models
{
    public class Reservation
    {
        public Ticket[] ReservedTickets { get; set; }
        public DateTime ReservedOn { get; set; }

        public bool Canceled { get; set; }

        public Reservation(Ticket[] reservedTickets, DateTime reservedOn)
        {
            ReservedTickets = reservedTickets;
            ReservedOn = reservedOn;
            Canceled = false;
        }
    }
}
