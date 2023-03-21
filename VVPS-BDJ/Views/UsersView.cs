using VVPS_BDJ.Utils;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.Views;
public class UsersView : View
{
    private readonly IEnumerable<KeyValuePair<string, Action>> _menuItems;

    public UsersView(IEnumerable<KeyValuePair<string, Action>> menuItems)
    {
        _menuItems = menuItems;
    }

    public void DisplayUsersMenu()
    {
        ConsoleMenu usersMenu = new(_menuItems, "Users Menu");
        usersMenu.Show();
    }

    private void DisplaySingleUser(User user)
    {
        string discountString =
            user.DiscountCard != null ?
            user.DiscountCard.GetType().Name :
            "None";

        string userAdminString = user.IsAdmin ? "Admin" : "User";

        Console.WriteLine("###########################################");
        Console.WriteLine(
            $"ID: {user.UserId} ({userAdminString}){Environment.NewLine}" +
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
    }

}
