using VVPS_BDJ.Models;
using VVPS_BDJ.Views;
using VVPS_BDJ.DAL;

namespace VVPS_BDJ.Controllers
{
    public class LoginController
    {
        private void ShowMainMenuAfterLogin()
        {
            MainConsole mainConsole = new();
            mainConsole.ShowMainMenu();
        }

        private LoginCredentials ShowLoginScreen(LoginConsole loginConsole) =>
            loginConsole.DisplayLoginCredentialsForm(false);

        private LoginCredentials ShowLoginScreenAfterFailedLogin(LoginConsole loginConsole) =>
            loginConsole.DisplayLoginCredentialsForm(true);

        private bool CheckLoginValid(LoginCredentials loginCredentials)
        {
            return BDJService.FindAdminByUsernameAndPassword(
                    loginCredentials.Username,
                    loginCredentials.Password
                ) != null;
        }

        public void LogInAsAdministrator()
        {
            LoginConsole loginConsole = new();
            LoginCredentials loginCredentials = ShowLoginScreen(loginConsole);

            while (CheckLoginValid(loginCredentials) == false)
                loginCredentials = ShowLoginScreenAfterFailedLogin(loginConsole);

            ShowMainMenuAfterLogin();
        }
    }
}
