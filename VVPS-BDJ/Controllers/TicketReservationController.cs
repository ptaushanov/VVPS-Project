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

    private IEnumerable<Reservation>? GetCurrentUserReservations(bool includeCanceled = false)
    {
        User? currentUser = (User?)SessionStorage.GetItem("Current-User");
        int? currentUserId = currentUser?.UserId;

        if (currentUserId == null)
        {
            ReturnToMenu();
            return null;
        }

        return BDJService.FindAllUserReservations((int)currentUserId, includeCanceled);
    }

    private void ViewReservations()
    {
        IEnumerable<Reservation>? reservations = GetCurrentUserReservations(true);
        if (reservations != null)
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
            // ticket.Price = TicketPricing.CalculateTotalPrice(ticket);

            tickets.Add(ticket);
        } while (_ticketReservationView.PromptUserForMoreTickets());

        bool confirmReservation = _ticketReservationView.PromptForReservationConfirmation();
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
        IEnumerable<Reservation>? reservations = GetCurrentUserReservations();
        if (reservations == null || reservations.Count() == 0)
        {
            ReturnToMenu();
            return;
        }

        Reservation? selectedReservation =
            _ticketReservationView.DisplayReservationSelectMenu(reservations);

        if (selectedReservation == null)
        {
            ReturnToMenu();
            return;
        }

        bool confirmCancellation = _ticketReservationView.PromptForCancellationConformation();
        if (confirmCancellation)
        {
            selectedReservation.Canceled = true;
            BDJService.ChangeReservation();
        }

        ReturnToMenu();
    }

    public TicketReservationController(TicketReservationView ticketReservationView) =>
        _ticketReservationView = ticketReservationView;

    private void GoBack()
    {
        new MainController().ShowMainMenu();
    }
}
