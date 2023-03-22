namespace VVPS_BDJ.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public bool IsTwoWay { get; set; }
        public bool ChildUnder16Present { get; set; }

        public DateTime DepartureDate { get; set; }

        public DiscountCard? UsedDiscountCard { get; set; }

        public double? Price { get; set; }

        public Ticket() { }

        public Ticket(
            int? ticketId, string fromCity, string toCity,
            bool isTwoWay = false, bool childUnder16Present = false
        )
        {
            TicketId = ticketId;
            FromCity = fromCity;
            ToCity = toCity;
            IsTwoWay = isTwoWay;

            UsedDiscountCard = null;

            Price = null;
            ChildUnder16Present = childUnder16Present;
        }

        internal void Deconstruct(
            out string fromCity, out string toCity, out bool isTwoWay,
            out DiscountCard? discountCard, out bool childUnder16Present,
            out DateTime departureDate
        )
        {
            fromCity = FromCity;
            toCity = ToCity;
            isTwoWay = IsTwoWay;
            discountCard = UsedDiscountCard;
            childUnder16Present = ChildUnder16Present;
            departureDate = DepartureDate;
        }
    }
}
