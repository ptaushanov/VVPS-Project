using VVPS_BDJ.DAL;
using VVPS_BDJ.Models;
using VVPS_BDJ.Views;

namespace VVPS_BDJ.Controllers
{
    public static class UsersController
    {
        private static readonly Dictionary<string, Action> _menuItems;

        static UsersController()
        {
            _menuItems = new()
            {
                { "List users", () => ListAllUsers() },
                { "Create a new user", () => Console.WriteLine("Two") },
                { "Update existing user", () => Console.WriteLine("Two") },
            };

            UsersView.LoadMenuItems(_menuItems);
        }

        public static void ShowUsersMenu() => UsersView.DisplayUsersMenu();

        private static void ListAllUsers() {
            IEnumerable<User> users = BDJService.FindAllUsers();
            UsersView.DisplayUserList(users);

            Console.ReadLine();
            ShowUsersMenu(); // Create own simple menu
        }
    }
}
