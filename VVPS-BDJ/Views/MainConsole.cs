using ConsoleTools;

namespace VVPS_BDJ.Views
{
    public class MainConsole
    {
        private readonly ConsoleMenu _mainMenu = new ConsoleMenu()
            .Add("One", () => Console.WriteLine("One"))
            .Add("Two", () => Console.WriteLine("Two"))
            .Add("Three", () => Console.WriteLine("Three"))
            .Add("Four", () => Console.WriteLine("Four"))
            .Configure(config =>
            {
                config.Selector = ">> ";
                config.EnableFilter = true;
                config.Title = "Main menu";
                config.EnableBreadcrumb = true;
            });

        public void ShowMainMenu() => _mainMenu.Show(); 
    }
}
