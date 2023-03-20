using VVPS_BDJ.Views;

namespace VVPS_BDJ.Controllers
{
    public static class MainController
    {
        private static Dictionary<string, Action> _menuItems;

        static MainController()
        {
            _menuItems = new()
            {
                { "Manage users (clients)",() => ShowUsersMenu() },
                { "Manage user discounts", () => Console.WriteLine("Two") },
                { "Search trains by departure/arrival location", () => Console.WriteLine("Three") },
                { "Search trains by departure/arrival time", () => Console.WriteLine("Three") },
                { "Manage reservations", () => Console.WriteLine("Three") }
            };

            MainView.LoadMenuItems(_menuItems);
        }

        public static void ShowMainMenu() => MainView.DisplayMainMenu();
        private static void ShowUsersMenu() => UsersController.ShowUsersMenu();
    }
}
