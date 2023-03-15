using System;
using System.Collections.Generic;
using System.Globalization;

namespace VVPS
{
    public static class TicketPricing
    {
        public static Dictionary<string, double> PricingTable { private get; set; }

        private static double CalculatePriceFromTimeOfDay
            (string fromCity, string toCity, DateTime departureDate)
        {
            const string searchKeyFormat = "{0}-{1}";
            const double discountPercentage = 0.05;

            const string stringMorningTime = "9:30";
            const string stringAfternoonTime = "16:00";
            const string stringEveningTime = "19:30";

            TimeSpan morningTime = TimeSpan
                .ParseExact(stringMorningTime, "h\\:mm", CultureInfo.CurrentCulture);
            TimeSpan afternoonTime = TimeSpan
                .ParseExact(stringAfternoonTime, "h\\:mm", CultureInfo.CurrentCulture);
            TimeSpan eveningTime = TimeSpan
                .ParseExact(stringEveningTime, "h\\:mm", CultureInfo.CurrentCulture);

            string searchKey = string.Format(searchKeyFormat, fromCity, toCity);

            if (PricingTable == null)
            {
                throw new NullReferenceException("PricingTable was null!");
            }

            if (!PricingTable.ContainsKey(searchKey))
            {
                throw new ArgumentException($"No price found for {searchKey}");
            }

            double basePrice = PricingTable[searchKey];

            bool isWithinTimeRange =
                departureDate.TimeOfDay > morningTime &&
                departureDate.TimeOfDay < afternoonTime &&
                departureDate.TimeOfDay > eveningTime;

            if (!isWithinTimeRange) return basePrice;

            return basePrice * (1 - discountPercentage);
        }

        private static double CalculatePriceFromDiscount
            (string fromCity, string toCity, DiscountCard discountCard, bool childUnder16Present)
        {
            const string searchKeyFormat = "{0}-{1}";
            string searchKey = string.Format(searchKeyFormat, fromCity, toCity);

            if (!PricingTable.ContainsKey(searchKey))
            {
                throw new ArgumentException($"No price found for {searchKey}");
            }

            if (discountCard is FamilyDiscountCard familyDiscoutCard)
                familyDiscoutCard.ChangeDiscount(childUnder16Present);

            double basePrice = PricingTable[searchKey];
            double discontedPrice =
                discountCard == null ?
                basePrice :
                basePrice * (1 - discountCard.DiscountValue);

            return discontedPrice;
        }

        public static double CalculateTotalPrice(Ticket ticket)
        {
            var (fromCity, toCity, isTwoWay, discountCard, childUnder16Present, departureDate) = ticket;
            double finalTicketPrice;

            finalTicketPrice =
                discountCard == null ?
                CalculatePriceFromTimeOfDay(fromCity, toCity, departureDate) :
                CalculatePriceFromDiscount(fromCity, toCity, discountCard, childUnder16Present);

            // Include one-way and two way trips
            finalTicketPrice = isTwoWay ? finalTicketPrice * 2 : finalTicketPrice;

            return finalTicketPrice;
        }
    }
}
