using ConsoleTools;

namespace VVPS_BDJ.Views
{
    public static class MainView
    {
        private static readonly ConsoleMenu _mainMenu;
        static MainView()
        {
            _mainMenu = new ConsoleMenu()
                .Configure(config =>
                {
                    config.Selector = ">> ";
                    config.Title = "Main menu";
                    config.EnableBreadcrumb = true;
                });
        }

        private static Action CreateSingleAction(Action action) => () =>
        {
            HideMainMenu();
            action();
        };

        public static void LoadMenuItems(IEnumerable<KeyValuePair<string, Action>> menuItems)
        {
            menuItems
                .ToList()
                .ForEach(menuItem =>
                    _mainMenu.Add(menuItem.Key, CreateSingleAction(menuItem.Value)
                ));
        }

        public static void DisplayMainMenu() => _mainMenu.Show();
        public static void HideMainMenu() => _mainMenu.CloseMenu();
    }
}
