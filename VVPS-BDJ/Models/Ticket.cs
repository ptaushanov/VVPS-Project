﻿namespace VVPS_BDJ.Models
{
    public class Ticket
    {
        public int? TicketId { get; private set; }
        public string FromCity { get; private set; }
        public string ToCity { get; private set; }
        public bool IsTwoWay { get; private set; }
        public bool ChildUnder16Present { get; private set; }

        public DateTime DepartureDate { get; set; }

        public DiscountCard? UsedDiscountCard { get; set; }

        public double? Price { get; set; }

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
