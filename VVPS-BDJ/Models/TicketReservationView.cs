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
}