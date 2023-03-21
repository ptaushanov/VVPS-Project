using VVPS_BDJ.Utils;

namespace VVPS_BDJ.Views;
public class MainView : View
{
    private readonly IEnumerable<KeyValuePair<string, Action>> _menuItems;

    public MainView(IEnumerable<KeyValuePair<string, Action>> menuItems)
    {
        _menuItems = menuItems;
    }

    public void DisplayMainMenu()
    {
        ConsoleMenu mainMenu = new(_menuItems, "Main Menu");
        mainMenu.Show();
    }
}
