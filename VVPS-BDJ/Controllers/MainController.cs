using VVPS_BDJ.Views;
using VVPS_BDJ.Utils;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.Controllers;

public class MainController
{
    private readonly MainView _mainView;

    // When I can't be bothered to use dependency injection
    public MainController()
    {
        Dictionary<string, Action> menuItems =
            new()
            {
                { "Manage users (clients and admins)", () => ShowUsersMenu() },
                { "Manage user discounts", () => ShowDiscountsMenu() },
                { "Search trains by departure/arrival location", () => ShowSearchByLocationMenu() },
                { "Search trains by departure/arrival time", () => ShowSearchByTimeMenu() },
                { "Manage reservations", () => ShowReservationMenu() },
                { "Exit", () => Environment.Exit(0) }
            };

        User? currentUser = (User?)SessionStorage.GetItem("Current-User");
        menuItems = FilterMenuItems(menuItems, currentUser);

        _mainView = new MainView(menuItems);
    }

    public MainController(MainView mainView) => _mainView = mainView;

    private Dictionary<string, Action> FilterMenuItems(
        Dictionary<string, Action> menuItems,
        User? currentUser
    )
    {
        if (currentUser != null && currentUser.IsAdmin)
        {
            Dictionary<string, Action> adminMenuItems = new();
            adminMenuItems = menuItems
                .Take(2)
                .Append(menuItems.Last())
                .ToDictionary(mItem => mItem.Key, mItem => mItem.Value);
            return adminMenuItems;
        }

        return menuItems.Skip(2).ToDictionary(mItem => mItem.Key, mItem => mItem.Value);
    }

    public void ShowMainMenu() => _mainView.DisplayMainMenu();

    private void ShowUsersMenu()
    {
        new UsersController().ShowUsersMenu();
    }

    private void ShowDiscountsMenu()
    {
        new DiscountsController().ShowDiscountsMenu();
    }

    private void ShowSearchByTimeMenu()
    {
        new TimetableController().ShowSearchByTimeMenu();
    }

    private void ShowSearchByLocationMenu()
    {
        new TimetableController().ShowSearchByLocationMenu();
    }

    private void ShowReservationMenu()
    {
        new TicketReservationController().ShowReservationMenu();
    }
}
