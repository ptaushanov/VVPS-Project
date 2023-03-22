using VVPS_BDJ.Models;
using VVPS_BDJ.Views;
using VVPS_BDJ.DAL;
using VVPS_BDJ.Utils;

namespace VVPS_BDJ.Controllers;

public class TicketReservationController
{
    private readonly TicketReservationView _ticketReservationView;

    // When I can't be bothered to use dependency injection
    public TicketReservationController()
    {
        Dictionary<string, Action> menuItems =
            new()
            {
                { "View my reservations", () => ViewReservations() },
                { "Create new reservation", () => CreateReservation() },
                { "Update reservation", () => UpdateReservation() },
                { "Cancel reservation", () => CancelReservation() },
                { "Go back", () => GoBack() },
            };

        _ticketReservationView = new TicketReservationView(menuItems);
    }

    private void ReturnToMenu()
    {
        _ticketReservationView.DisplayPause();
        _ticketReservationView.DisplayReservationMenu();
    }

    public void ShowReservationMenu()
    {
        _ticketReservationView.DisplayReservationMenu();
    }

    private void ViewReservations()
    {
        User? currentUser = (User?)SessionStorage.GetItem("Current-User");
        int? currentUserId = currentUser?.UserId;

        if (currentUserId == null)
        {
            Console.WriteLine("You are not logged in.");
            ReturnToMenu();
            return;
        }

        IEnumerable<Reservation> reservations = BDJService.FindAllUserReservations((int)currentUserId);
        _ticketReservationView.DisplayUserReservations(reservations);
        ReturnToMenu();
    }

    private void CreateReservation()
    {
        IEnumerable<TimetableRecord> timetable = BDJService.FindAllTimetableRecords();
        List<Ticket> tickets = new();

        do
        {
            TimetableRecord? selectedRecord = _ticketReservationView.DisplayTimetable(timetable);
            if (selectedRecord == null)
            {
                ReturnToMenu();
                return;
            }

            Ticket ticket = _ticketReservationView.DisplayTicketForm(selectedRecord);
            tickets.Add(ticket);
        } while (_ticketReservationView.PromptUserForMoreTickets());

        bool confirmReservation = _ticketReservationView.PromptUserForConfirmation();
        if (confirmReservation)
        {
            User? currentUser = (User?)SessionStorage.GetItem("Current-User");
            int currentUserId = currentUser?.UserId ?? 0;

            Reservation reservation = TicketReservation.ReserveTickets(
                tickets,
                DateTime.Now,
                currentUserId
            );

            BDJService.AddReservation(reservation);
        }

        ReturnToMenu();
    }

    private void UpdateReservation()
    {
        throw new NotImplementedException();
    }

    private void CancelReservation()
    {
        throw new NotImplementedException();
    }

    public TicketReservationController(TicketReservationView ticketReservationView) =>
        _ticketReservationView = ticketReservationView;

    private void GoBack()
    {
        new MainController().ShowMainMenu();
    }
}
