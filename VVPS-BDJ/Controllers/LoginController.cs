using VVPS_BDJ.Models;
using VVPS_BDJ.Views;
using VVPS_BDJ.DAL;

namespace VVPS_BDJ.Controllers;
public class LoginController
{
    private readonly LoginView _loginView;

    // When I can't be bothered to use dependency injection
    public LoginController() => _loginView = new LoginView();

    public LoginController(LoginView loginView) => _loginView = loginView;

    private LoginCredentials ShowLoginScreen() =>
        _loginView.DisplayLoginCredentialsForm(false);

    private LoginCredentials ShowLoginScreenAfterFailedLogin() =>
        _loginView.DisplayLoginCredentialsForm(true);

    private bool CheckLoginValid(LoginCredentials loginCredentials)
    {
        return BDJService.FindAdminByUsernameAndPassword(
                loginCredentials.Username,
                loginCredentials.Password
            ) != null;
    }

    public void LogInAsAdministrator()
    {
        LoginCredentials loginCredentials = ShowLoginScreen();

        while (CheckLoginValid(loginCredentials) == false)
            loginCredentials = ShowLoginScreenAfterFailedLogin();

        new MainController().ShowMainMenu();
    }
}
