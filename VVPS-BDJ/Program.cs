using VVPS_BDJ.Controllers;

namespace VVPS_BDJ
{
    public class Program
    {
        static void Main(string[] args)
        {
            LoginController loginController = new();
            loginController.LogInAsAdministrator();
        }
    }
}
