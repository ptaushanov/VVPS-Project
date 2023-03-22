using VVPS_BDJ.DAL;
using VVPS_BDJ.Models;
using VVPS_BDJ.Views;

namespace VVPS_BDJ.Controllers;

public class DiscountsController
{
    private readonly DiscountsView _discountsView;
    private readonly Dictionary<int, string> _discountCardTypesForUser;

    // When I can't be bothered to use dependency injection
    public DiscountsController()
    {
        Dictionary<string, Action> menuItems =
            new()
            {
                { "View discount cards per user", () => ViewDiscountCardsPerUser()},
                { "Add/Change user discount card", () => AddOrChangeDiscountCard() },
                { "Revoke user discount card", () => RevokeDiscountCard() },
                { "Go Back", () => GoBack() },
            };
        _discountsView = new DiscountsView(menuItems);

        _discountCardTypesForUser = new()
        {
            { 0, "Family discount card" },
            { 1, "Elderly discount card" }
        };
    }

    private void ReturnToMenu()
    {
        _discountsView.DisplayPause();
        _discountsView.DisplayDiscountsMenu();
    }

    public DiscountsController(DiscountsView usersView)
    {
        _discountsView = usersView;
        _discountCardTypesForUser = new();
    }

    public DiscountsController(
        DiscountsView usersView,
        Dictionary<int, string> discountCardTypesForUser
    )
    {
        _discountsView = usersView;
        _discountCardTypesForUser = discountCardTypesForUser;
    }

    public void ShowDiscountsMenu() => _discountsView.DisplayDiscountsMenu();

    private void ViewDiscountCardsPerUser()
    {
        _discountsView
            .DisplayUserDiscountCards(BDJService.FindAllUsers());
        ReturnToMenu();
    }

    private void AddOrChangeDiscountCard()
    {
        IEnumerable<User> users = BDJService.FindAllUsers();
        int? userId = _discountsView.DisplayUserSelectMenu(users);

        if (userId == null)
        {
            ReturnToMenu();
            return;
        }

        User? user = BDJService.FindUserById((int)userId);

        if (user == null)
        {
            ReturnToMenu();
            return;
        }

        int ageOfUser = DateTime.Now.Year - user.DateOfBirth.Year;

        // Clone the dictionary so we don't modify the original
        Dictionary<int, string> discountCardTypesForUser =
            _discountCardTypesForUser.ToDictionary(
                discountCardType => discountCardType.Key,
                discountCardType => discountCardType.Value
            );

        // Remove the elderly discount card if the user is not elderly
        if (ageOfUser < 65)
            discountCardTypesForUser.Remove(1);

        int discountCardType = _discountsView.DisplayDiscountCardSelectMenu(
            discountCardTypesForUser
        );

        if (discountCardType == -1)
        {
            ReturnToMenu();
            return;
        }

        DiscountCard discountCard;

        switch (discountCardType)
        {
            case 0:
                discountCard = new FamilyDiscountCard();
                break;
            case 1:
                discountCard = new ElderlyDiscountCard();
                break;
            default:
                ReturnToMenu();
                return;
        }

        BDJService.AddDiscountCard(discountCard);
        user.DiscountCard = discountCard;
        BDJService.UpdateUser();

        ReturnToMenu();
    }

    private void RevokeDiscountCard()
    {
        IEnumerable<User> users = BDJService.FindAllUsers();
        int? userId = _discountsView.DisplayUserDiscountCards(users);

        if (userId == null)
        {
            ReturnToMenu();
            return;
        }

        User? user = BDJService.FindUserById((int)userId);

        if (user == null)
        {
            ReturnToMenu();
            return;
        }

        if (user.DiscountCard == null)
        {
            ReturnToMenu();
            return;
        }

        BDJService.DeleteDiscountCard(user.DiscountCard);
        user.DiscountCard = null;
        BDJService.UpdateUser();

        ReturnToMenu();
    }

    private void GoBack()
    {
        new MainController()
        .ShowMainMenu();
    }
}
