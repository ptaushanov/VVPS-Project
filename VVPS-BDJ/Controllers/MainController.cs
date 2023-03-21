using VVPS_BDJ.Views;

namespace VVPS_BDJ.Controllers;
public class MainController
{
    private readonly MainView _mainView;

    // When I can't be bothered to use dependency injection
    public MainController()
    {
        Dictionary<string, Action> menuItems = new()
            {
                { "Manage users (clients)",() => ShowUsersMenu() },
                { "Manage user discounts", () => ShowDiscountsMenu() },
                { "Search trains by departure/arrival location", () => Console.WriteLine("Three") },
                { "Search trains by departure/arrival time", () => Console.WriteLine("Three") },
                { "Manage reservations", () => Console.WriteLine("Three") },
                { "Exit", () => Environment.Exit(0) }
            };

        _mainView = new MainView(menuItems);
    }

    public MainController(MainView mainView) => _mainView = mainView;

    public void ShowMainMenu() => _mainView.DisplayMainMenu();
    private void ShowUsersMenu()
    {
        new UsersController()
        .ShowUsersMenu();
    }

    private void ShowDiscountsMenu()
    {
        new DiscountsController()
        .ShowDiscountsMenu();
    }
}
