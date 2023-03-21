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

    public User DisplayCreateUserForm()
    {
        Console.Clear();
        Console.WriteLine("[Create new user]" + Environment.NewLine);

        Console.Write("First name: ");
        string firstName = Console.ReadLine() ?? string.Empty;

        Console.Write("Last name: ");
        string lastName = Console.ReadLine() ?? string.Empty;

        Console.Write("Username: ");
        string username = Console.ReadLine() ?? string.Empty;

        Console.Write("Password: ");
        string password = Console.ReadLine() ?? string.Empty;

        Console.Write("Date of birth (dd.mm.yyyy): ");
        string dateOfBirthString = Console.ReadLine() ?? string.Empty;
        DateTime dateOfBirth;
        bool isParsingSuccessful = DateTime.TryParse(dateOfBirthString, out dateOfBirth);

        while (!isParsingSuccessful)
        {
            Console.WriteLine("Invalid date format. Please try again.");
            Console.Write("Date of birth (dd.mm.yyyy): ");
            dateOfBirthString = Console.ReadLine() ?? string.Empty;
            isParsingSuccessful = DateTime.TryParse(dateOfBirthString, out dateOfBirth);
        }

        Console.Write("Is admin? (y/N): ");
        string isAdminString = Console.ReadLine() ?? string.Empty;
        bool isAdmin = isAdminString.ToLower() == "y";

        return new User(
            null,
            firstName,
            lastName,
            username,
            password,
            dateOfBirth,
            isAdmin
        );
    }

}
