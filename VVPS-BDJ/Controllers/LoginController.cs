using VVPS_BDJ.Models;
using VVPS_BDJ.Views;
using VVPS_BDJ.DAL;
using VVPS_BDJ.Utils;

namespace VVPS_BDJ.Controllers;

public class LoginController
{
    private readonly LoginView _loginView;

    // When I can't be bothered to use dependency injection
    public LoginController() => _loginView = new LoginView();

    public LoginController(LoginView loginView) => _loginView = loginView;

    private LoginCredentials ShowLoginScreen() => _loginView.DisplayLoginCredentialsForm(false);

    private LoginCredentials ShowLoginScreenAfterFailedLogin() =>
        _loginView.DisplayLoginCredentialsForm(true);

    private User? FindUserByCredentials(LoginCredentials loginCredentials)
    {
        return BdjService.FindUserByUsernameAndPassword(
            loginCredentials.Username,
            loginCredentials.Password
        );
    }

    public void LogIn()
    {
        LoginCredentials loginCredentials = ShowLoginScreen();
        User? user = FindUserByCredentials(loginCredentials);

        while (user == null)
        {
            loginCredentials = ShowLoginScreenAfterFailedLogin();
            user = FindUserByCredentials(loginCredentials);
        }

        SessionStorage.SetItem("Current-User", user);
        new MainController().ShowMainMenu();
    }
}
