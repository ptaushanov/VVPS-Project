using VVPS_BDJ.Controllers;
using VVPS_BDJ.Utils;

namespace VVPS_BDJ
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExecutionChain executionChain = new();
            executionChain
                .Add(() => LoginController.LogInAsAdministrator())
                .Add(() => MainController.ShowMainMenu())
                .Execute();
        }
    }
}
