using VVPS_BDJ.Utils;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.Views;

public class TicketReservationView : View
{
    private readonly IEnumerable<KeyValuePair<string, Action>> _menuItems;

    public TicketReservationView(IEnumerable<KeyValuePair<string, Action>> menuItems)
    {
        _menuItems = menuItems;
    }

    public void DisplayReservationMenu()
    {
        ConsoleMenu reservationMenu = new(_menuItems, "Ticket Reservation Menu");
        reservationMenu.Show();
    }

    private string FormatTimetableRecord(TimetableRecord record)
    {
        string formattedRecord =
            $"{record.DepartureLocation} -> {record.ArrivalLocation} | "
            + $"{record.DepartureTime} -> {record.ArrivalTime}";
        return formattedRecord;
    }

    public TimetableRecord? DisplayTimetable(IEnumerable<TimetableRecord> timetable)
    {
        TimetableRecord? selectedRecord = null;

        ConsoleMenu timetableMenu =
            new(timetable.Select(
                record =>
                    new KeyValuePair<string, Action>(
                        FormatTimetableRecord(record),
                        () => selectedRecord = record
                    )
                ),
                "Select train from timetable"
            );

        timetableMenu.Show();

        return selectedRecord;
    }

    private DateOnly TakeDepartureDate(string dateOfBirthString, TimeOnly departureTime)
    {
        bool isDateCorrect = DateOnly.TryParse(dateOfBirthString, out DateOnly departureDate);
        if (isDateCorrect)
            isDateCorrect = departureDate.ToDateTime(departureTime) > DateTime.Now;

        while (!isDateCorrect)
        {
            Console.WriteLine("Invalid departure date. Please try again.");
            Console.Write("Departure date (dd.mm.yyyy): ");
            dateOfBirthString = Console.ReadLine() ?? string.Empty;
            isDateCorrect = DateOnly.TryParse(dateOfBirthString, out departureDate);
            if (isDateCorrect)
                isDateCorrect = departureDate.ToDateTime(departureTime) > DateTime.Now;
        }

        return departureDate;
    }

    public bool PromptUserForMoreTickets()
    {
        Console.WriteLine();
        Console.Write("Do you want to add more tickets? (y/N) ");
        string answer = Console.ReadLine() ?? string.Empty;

        return answer == "y";
    }

    public bool PromptForReservationConfirmation()
    {
        Console.WriteLine();
        Console.Write("Confirm reservation? (y/N) ");
        string answer = Console.ReadLine() ?? string.Empty;

        return answer == "y";
    }

    public Ticket DisplayTicketForm(TimetableRecord selectedRecord)
    {
        Ticket ticket = new()
        {
            FromCity = selectedRecord.DepartureLocation,
            ToCity = selectedRecord.ArrivalLocation
        };

        Console.WriteLine();
        Console.Write("Departure date (dd.mm.yyyy): ");
        string departureDateAsString = Console.ReadLine() ?? string.Empty;
        DateOnly departureDate = TakeDepartureDate(departureDateAsString, selectedRecord.DepartureTime);

        ticket.DepartureDate = departureDate.ToDateTime(selectedRecord.DepartureTime);

        Console.Write("Is the ticket two-way? (y/N) ");
        ticket.IsTwoWay = Console.ReadLine() == "y";

        Console.Write("Is there a child under 16? (y/N) ");
        ticket.ChildUnder16Present = Console.ReadLine() == "y";

        return ticket;
    }

    private string FormatTicket(Ticket ticket)
    {
        string formattedTicket =
            Environment.NewLine
            + $"From: {ticket.FromCity}{Environment.NewLine}"
            + $"To: {ticket.ToCity}{Environment.NewLine}"
            + $"Departure date: {ticket.DepartureDate}{Environment.NewLine}"
            + $"Is two-way: {ticket.IsTwoWay}{Environment.NewLine}"
            + $"Child under 16 present: {ticket.ChildUnder16Present}{Environment.NewLine}";

        return formattedTicket;
    }

    private string FormatReservation(Reservation reservation)
    {
        string reservationStatus = reservation.Canceled ? "Canceled" : "Active";
        string formattedReservation =
            "###########################################"
            + Environment.NewLine
            + $"Reserved on: {reservation.ReservedOn}{Environment.NewLine}"
            + $"Status: {reservationStatus}"
            + Environment.NewLine
            + string.Join(
                Environment.NewLine,
                reservation.ReservedTickets.Select(ticket => FormatTicket(ticket))
            )
            + "###########################################"
            + Environment.NewLine;

        return formattedReservation;
    }

    private string FormatReservationForSelecting(Reservation reservation)
    {
        string reservationStatus = reservation.Canceled ? "Canceled" : "Active";
        string formattedReservation =
            $"Reserved on: {reservation.ReservedOn} | Status: {reservationStatus} | " +
            $"Tickets: {reservation.ReservedTickets.Count()}";
        return formattedReservation;
    }

    public void DisplayUserReservations(IEnumerable<Reservation> reservations)
    {
        Console.Clear();
        Console.WriteLine("[Your reservations]" + Environment.NewLine);

        reservations
            .Select(reservation => FormatReservation(reservation))
            .ToList()
            .ForEach(Console.WriteLine);
    }


    public Reservation? DisplayReservationSelectMenu(IEnumerable<Reservation> reservations)
    {
        Reservation? selectedReservation = null;

        ConsoleMenu reservationSelectMenu =
            new(reservations.Select(
                reservation =>
                    new KeyValuePair<string, Action>(
                        FormatReservationForSelecting(reservation),
                        () => selectedReservation = reservation
                    )
                ),
                "Select reservation"
            );

        reservationSelectMenu.Show();
        return selectedReservation;
    }

    public bool PromptForCancellationConformation()
    {
        Console.Clear();
        Console.Write("Are you sure you want to cancel this reservation? (y/N) ");
        string answer = Console.ReadLine() ?? string.Empty;
        bool isConfirmed = answer == "y";
        return isConfirmed;
    }
}
