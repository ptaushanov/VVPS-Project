using ConsoleTools;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.Views
{
    public static class UsersView
    {
        private static readonly ConsoleMenu _userActionMenu;

        static UsersView()
        {
            _userActionMenu = new ConsoleMenu()
                .Configure(config =>
                {
                    config.Selector = ">> ";
                    config.Title = "Manage users menu";
                    config.EnableBreadcrumb = true;
                });
        }

        private static Action CreateSingleAction(Action action) => () =>
        {
            HideUserMenu();
            action();
        };

        public static void LoadMenuItems(IEnumerable<KeyValuePair<string, Action>> menuItems)
        {
            menuItems
                .ToList()
                .ForEach(menuItem =>
                    _userActionMenu.Add(menuItem.Key, CreateSingleAction(menuItem.Value)
                ));

        }

        public static void DisplayUsersMenu() => _userActionMenu.Show();
        private static void HideUserMenu() => _userActionMenu.CloseMenu();

        private static void DisplaySingleUser(User user)
        {
            string discountString = 
                user.DiscountCard != null ? 
                user.DiscountCard.GetType().Name :
                "None";

            Console.WriteLine("###########################################");
            Console.WriteLine(
                $"ID: {user.UserId}{Environment.NewLine}" +
                $"First name: {user.FirstName}{Environment.NewLine}" +
                $"Last name: {user.LastName}{Environment.NewLine}" +
                $"Username: {user.Username}{Environment.NewLine}" +
                $"Date of birth: {user.DateOfBirth}{Environment.NewLine}" +
                $"Discount type: {discountString}"
                );
            Console.WriteLine("###########################################" + Environment.NewLine);
        }

        public static void DisplayUserList(IEnumerable<User> users)
        {
            Console.Clear();
            Console.WriteLine("[List of users]" + Environment.NewLine);

            users
                .ToList()
                .ForEach(user => DisplaySingleUser(user));

            //DisplayUsersMenu();
        }

    }
}
