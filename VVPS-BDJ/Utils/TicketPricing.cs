using System.Globalization;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.Utils;

public static class TicketPricing
{
    private static double CalculatePriceFromTimeOfDay(double basePrice, DateTime departureDate)
    {
        const double discountPercentage = 0.05;

        const string stringMorningTime = "9:30";
        const string stringAfternoonTime = "16:00";
        const string stringEveningTime = "19:30";

        TimeSpan morningTime = TimeSpan.ParseExact(
            stringMorningTime,
            "h\\:mm",
            CultureInfo.CurrentCulture
        );
        TimeSpan afternoonTime = TimeSpan.ParseExact(
            stringAfternoonTime,
            "h\\:mm",
            CultureInfo.CurrentCulture
        );
        TimeSpan eveningTime = TimeSpan.ParseExact(
            stringEveningTime,
            "h\\:mm",
            CultureInfo.CurrentCulture
        );

        bool isWithinTimeRange =
            departureDate.TimeOfDay > morningTime && departureDate.TimeOfDay < afternoonTime
            || departureDate.TimeOfDay > eveningTime;

        if (!isWithinTimeRange)
            return basePrice;

        return basePrice * (1 - discountPercentage);
    }

    private static double CalculatePriceFromDiscount(
        double basePrice,
        DiscountCard discountCard,
        bool childUnder16Present
    )
    {
        if (discountCard is FamilyDiscountCard familyDiscountCard)
            familyDiscountCard.ChangeDiscount(childUnder16Present);

        double discountedPrice =
            discountCard == null ? basePrice : basePrice * (1 - discountCard.DiscountValue);

        return discountedPrice;
    }

    public static double CalculateTotalPrice(Ticket ticket, double basePrice)
    {
        var (fromCity, toCity, isTwoWay, discountCard, childUnder16Present, departureDate) = ticket;
        double finalTicketPrice;

        finalTicketPrice =
            discountCard == null
                ? CalculatePriceFromTimeOfDay(basePrice, departureDate)
                : CalculatePriceFromDiscount(basePrice, discountCard, childUnder16Present);

        // Include one-way and two-way trips
        finalTicketPrice = isTwoWay ? finalTicketPrice * 2 : finalTicketPrice;

        return finalTicketPrice;
    }
}
