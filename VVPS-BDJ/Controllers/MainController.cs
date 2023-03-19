using VVPS_BDJ.Views;

namespace VVPS_BDJ.Controllers
{
    public static class MainController {
        public static bool ShowMainMenu()
        {
            MainView mainView = new();
            mainView.ShowMainMenu();
            return true;
        }
    }
}
