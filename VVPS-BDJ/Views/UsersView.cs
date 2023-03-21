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
            user.DiscountCard != null ? user.DiscountCard.GetType().Name : "None";

        string userAdminString = user.IsAdmin ? "Admin" : "User";

        Console.WriteLine("###########################################");
        Console.WriteLine(
            $"ID: {user.UserId} ({userAdminString}){Environment.NewLine}"
                + $"First name: {user.FirstName}{Environment.NewLine}"
                + $"Last name: {user.LastName}{Environment.NewLine}"
                + $"Username: {user.Username}{Environment.NewLine}"
                + $"Date of birth: {user.DateOfBirth}{Environment.NewLine}"
                + $"Discount type: {discountString}"
        );
        Console.WriteLine("###########################################" + Environment.NewLine);
    }

    public void DisplayUserList(IEnumerable<User> users)
    {
        Console.Clear();
        Console.WriteLine("[List of users]" + Environment.NewLine);

        users.ToList().ForEach(user => DisplaySingleUser(user));
    }

    public User TakeUserDetails(bool isEdit = false)
    {
        Console.Write("First name: ");
        string firstName = Console.ReadLine() ?? string.Empty;

        Console.Write("Last name: ");
        string lastName = Console.ReadLine() ?? string.Empty;

        Console.Write("Username: ");
        string username = Console.ReadLine() ?? string.Empty;

        Console.Write("Password: ");
        string password = Console.ReadLine() ?? string.Empty;

        DateTime dateOfBirth = DateTime.MinValue;
        bool isAdmin = false;

        if (!isEdit)
        {
            Console.Write("Date of birth (dd.mm.yyyy): ");
            string dateOfBirthString = Console.ReadLine() ?? string.Empty;
            dateOfBirth = TakeDateOfBirth(dateOfBirthString);
            isAdmin = TakeAdminStatus(isEdit);
        }

        return new User(null, firstName, lastName, username, password, dateOfBirth, isAdmin);
    }

    private bool TakeAdminStatus(bool isEdit)
    {
        bool isAdmin = false;

        if (!isEdit)
        {
            Console.Write("Is admin? (y/N): ");
            string isAdminString = Console.ReadLine() ?? string.Empty;
            isAdmin = isAdminString.ToLower() == "y";
        }

        return isAdmin;
    }

    private DateTime TakeDateOfBirth(string dateOfBirthString)
    {
        DateTime dateOfBirth;
        bool isParsingSuccessful = DateTime.TryParse(dateOfBirthString, out dateOfBirth);

        while (!isParsingSuccessful)
        {
            Console.WriteLine("Invalid date format. Please try again.");
            Console.Write("Date of birth (dd.mm.yyyy): ");
            dateOfBirthString = Console.ReadLine() ?? string.Empty;
            isParsingSuccessful = DateTime.TryParse(dateOfBirthString, out dateOfBirth);
        }

        return dateOfBirth;
    }

    public User DisplayCreateUserForm()
    {
        Console.Clear();
        Console.WriteLine("[Create new user]" + Environment.NewLine);
        return TakeUserDetails();
    }

    private string CreateSelectableUser(User user)
    {
        string userAdminString = user.IsAdmin ? "Admin" : "User";
        string userAsString =
            $"ID: {user.UserId} - {user.FirstName}"
            + $" {user.LastName} [{user.Username}] ({userAdminString})";

        return userAsString;
    }

    public int? DisplayUserSelectMenu(IEnumerable<User> users)
    {
        int? selectedIndexOfUser = null;

        Action<User> HandleSelectAction = (user) => { };

        ConsoleMenu userSelectMenu = new("Select user to update");

        users
            .ToList()
            .ForEach(user =>
            {
                userSelectMenu.Add(
                    CreateSelectableUser(user),
                    () => selectedIndexOfUser = user.UserId
                );
            });

        userSelectMenu.Show();
        return selectedIndexOfUser;
    }

    public User DisplayUpdateUserForm()
    {
        Console.Clear();
        Console.WriteLine("[Update user]" + Environment.NewLine);
        return TakeUserDetails(true);
    }
}
