using VVPS_BDJ.Models;

namespace VVPS_BDJ.Views
{
    public class LoginConsole
    {
        public LoginCredentials DisplayLoginCredentialsForm(bool isLoginFailed = false)
        {
            Console.Clear();
            Console.WriteLine("[Login Form]" + Environment.NewLine);

            if (isLoginFailed)
                Console.WriteLine("Login failed. Please try again." + Environment.NewLine);

            Console.Write("Enter your username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("Enter your password: ");
            string password = Console.ReadLine() ?? "";

            return new LoginCredentials(username, password);
        }
    }
}
