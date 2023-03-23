using VVPS_BDJ.DAL;
using VVPS_BDJ.Models;
using VVPS_BDJ.Views;

namespace VVPS_BDJ.Controllers;
public class UsersController
{
    private readonly UsersView _usersView;

    // When I can't be bothered to use dependency injection
    public UsersController()
    {
        Dictionary<string, Action> menuItems = new()
            {
                { "List users", () => ListAllUsers() },
                { "Create a new user", () => CreateNewUser() },
                { "Update existing user", () => UpdateUser() },
                { "Go Back", () => GoBack() },
            };
        _usersView = new UsersView(menuItems);
    }

    public UsersController(UsersView usersView) => _usersView = usersView;

    public void ShowUsersMenu() => _usersView.DisplayUsersMenu();

    private void ReturnToMenu()
    {
        _usersView.DisplayPause();
        _usersView.DisplayUsersMenu();
    }

    private void ListAllUsers()
    {
        IEnumerable<User> users = BdjService.FindAllUsers();
        _usersView.DisplayUserList(users);
        ReturnToMenu();
    }

    private void CreateNewUser()
    {
        User newUser = _usersView.DisplayCreateUserForm();
        BdjService.AddUser(newUser);
        ReturnToMenu();
    }

    private void UpdateUser()
    {
        // Get user ID after displaying list of users
        IEnumerable<User> users = BdjService.FindAllUsers();
        int? userId = _usersView.DisplayUserSelectMenu(users);

        if (userId == null)
        {
            ReturnToMenu();
            return;
        }

        User? dbUser = BdjService.FindUserById((int)userId);

        if (dbUser == null)
        {
            ReturnToMenu();
            return;
        }

        User user = _usersView.DisplayUpdateUserForm();
        dbUser.CopyProperties(user, skipEmptyValues: true);

        BdjService.UpdateUser();
        ReturnToMenu();
    }

    private void GoBack()
    {
        new MainController()
        .ShowMainMenu();
    }
}
