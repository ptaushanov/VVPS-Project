using VVPS_BDJ.Utils;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.Views;
public class UsersView
{
    private readonly IEnumerable<KeyValuePair<string, Action>> menuItems;

    public UsersView(IEnumerable<KeyValuePair<string, Action>> menuItems)
    {
        this.menuItems = menuItems;
    }

    public void DisplayUsersMenu()
    {
        ConsoleMenu usersMenu = new(menuItems);
        usersMenu.Show();
    }

    private void DisplaySingleUser(User user)
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

    public void DisplayUserList(IEnumerable<User> users)
    {
        Console.Clear();
        Console.WriteLine("[List of users]" + Environment.NewLine);

        users
            .ToList()
            .ForEach(user => DisplaySingleUser(user));

        DisplayUsersMenu();
    }

}
