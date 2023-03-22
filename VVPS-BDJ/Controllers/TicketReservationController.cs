using VVPS_BDJ.Models;
using VVPS_BDJ.Views;

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
                { "Create new reservation", () => CreateReservation() },
                { "View my reservations", () => ViewReservations() },
                { "Update reservation", () => UpdateReservation() },
                { "Cancel reservation", () => CancelReservation() },
                { "Go back", () => GoBack() },
            };

        _ticketReservationView = new TicketReservationView(menuItems);
    }

    public void ShowReservationMenu()
    {
        _ticketReservationView.DisplayReservationMenu();
    }

    private void ViewReservations()
    {
        throw new NotImplementedException();
    }

    private void CreateReservation()
    {
        throw new NotImplementedException();
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
        new MainController()
        .ShowMainMenu();
    }
}
