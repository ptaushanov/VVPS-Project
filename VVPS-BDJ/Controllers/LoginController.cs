using VVPS_BDJ.Models;
using VVPS_BDJ.Views;
using VVPS_BDJ.DAL;

namespace VVPS_BDJ.Controllers
{
    public static class LoginController
    {
        private static LoginCredentials ShowLoginScreen() =>
            LoginView.DisplayLoginCredentialsForm(false);

        private static LoginCredentials ShowLoginScreenAfterFailedLogin() =>
            LoginView.DisplayLoginCredentialsForm(true);

        private static bool CheckLoginValid(LoginCredentials loginCredentials)
        {
            return BDJService.FindAdminByUsernameAndPassword(
                    loginCredentials.Username,
                    loginCredentials.Password
                ) != null;
        }

        public static void LogInAsAdministrator()
        {
            LoginCredentials loginCredentials = ShowLoginScreen();

            while (CheckLoginValid(loginCredentials) == false)
                loginCredentials = ShowLoginScreenAfterFailedLogin();

            MainController.ShowMainMenu();
        }
    }
}
