namespace VVPS_BDJ.Utils;

public class ConsoleMenu
{
    private readonly List<KeyValuePair<string, Action>> _menuItems;
    private int _selectedMenuItemIndex;

    public ConsoleMenu() => _menuItems = new List<KeyValuePair<string, Action>>();

    public ConsoleMenu(IEnumerable<KeyValuePair<string, Action>> menuItems) =>
        _menuItems = new List<KeyValuePair<string, Action>>(menuItems);

    public ConsoleMenu Add(string displayName, Action action)
    {
        _menuItems.Add(new KeyValuePair<string, Action>(displayName, action));
        return this;
    }

    public void Show()
    {
        Console.CursorVisible = false;

        while (true)
        {
            Console.Clear();
            DisplayMenuItems();
            bool isActionActive = GetUserInput();
            if (!isActionActive) break;
        }
    }

    private bool GetUserInput()
    {
        // Get user input
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
                _selectedMenuItemIndex--;
                if (_selectedMenuItemIndex < 0)
                    _selectedMenuItemIndex = _menuItems.Count - 1;
                break;
            case ConsoleKey.DownArrow:
                _selectedMenuItemIndex++;
                if (_selectedMenuItemIndex >= _menuItems.Count)
                    _selectedMenuItemIndex = 0;
                break;
            case ConsoleKey.Enter:
                _menuItems[_selectedMenuItemIndex].Value.Invoke();
                return true;
        }
        return false;
    }

    private void DisplayMenuItems()
    {
        // Display menu items with formatting
        _menuItems
            .ToList()
            .ForEach(DisplaySingleItem());
    }

    private Action<KeyValuePair<string, Action>> DisplaySingleItem()
    {
        int index = 1;
        return (item) =>
        {
            string menuItemString = $"[{index}] {item.Key}";
            if (index == _selectedMenuItemIndex)
                Console.WriteLine($">> {menuItemString}");
            else
                Console.WriteLine($"   {menuItemString}");
            index++;
        };
    }
}
