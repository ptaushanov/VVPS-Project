using System.Text;
using VVPS_BDJ.Controllers;
using System.Globalization;

Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
Console.OutputEncoding = Encoding.Unicode;
// PRODUCTION CODE:
LoginController loginController = new();
loginController.LogIn();

// TEST CODE:
// MainController mainController = new();
// mainController.ShowMainMenu();