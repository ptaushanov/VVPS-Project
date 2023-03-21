using System.Text;
using VVPS_BDJ.Controllers;

Console.OutputEncoding = Encoding.Unicode;
// PRODUCTION CODE:
// LoginController loginController = new();
// loginController.LogInAsAdministrator();

// TEST CODE:
MainController mainController = new();
mainController.ShowMainMenu();