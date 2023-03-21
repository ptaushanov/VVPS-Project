using VVPS_BDJ.Utils;

namespace VVPS_BDJ.Views;
public class MainView
{
    private readonly IEnumerable<KeyValuePair<string, Action>> menuItems;

    public MainView(IEnumerable<KeyValuePair<string, Action>> menuItems)
    {
        this.menuItems = menuItems;
    }

    public void DisplayMainMenu()
    {
        ConsoleMenu mainMenu = new(menuItems);
        mainMenu.Show();
    }
}
