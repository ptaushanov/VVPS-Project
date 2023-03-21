using VVPS_BDJ.Models;

namespace VVPS_BDJ.Views;
public class LoginView : View
{
    public LoginCredentials DisplayLoginCredentialsForm(bool isLoginFailed = false)
    {
        Console.Clear();
        Console.WriteLine(
            "========================================" + Environment.NewLine +
                "    VVPS - Train Reservation System" + Environment.NewLine +
            "========================================" + Environment.NewLine
        );
        Console.WriteLine("[Login Form]" + Environment.NewLine);

        if (isLoginFailed)
            Console.WriteLine("Login failed. Please try again." + Environment.NewLine);

        Console.Write("Enter your username: ");
        string username = Console.ReadLine() ?? string.Empty;
        Console.Write("Enter your password: ");
        string password = Console.ReadLine() ?? string.Empty;

        return new LoginCredentials(username, password);
    }
}