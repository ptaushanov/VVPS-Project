using VVPS_BDJ.Utils;
using VVPS_BDJ.Models;

namespace VVPS_BDJ.Views;

public class DiscountsView : View
{
    private readonly IEnumerable<KeyValuePair<string, Action>> _menuItems;

    public DiscountsView(IEnumerable<KeyValuePair<string, Action>> menuItems)
    {
        _menuItems = menuItems;
    }

    public void DisplayDiscountsMenu()
    {
        ConsoleMenu discountsMenu = new(_menuItems, "Discounts Menu");
        discountsMenu.Show();
    }

    private string CreateSelectableUser(User user)
    {
        int userAge = DateTime.Now.Year - user.DateOfBirth.Year;
        string userAsString =
            $"{user.FirstName} {user.LastName} [{user.Username}]" + $"(Age: {userAge})";

        return userAsString;
    }

    public int? DisplayUserSelectMenu(IEnumerable<User> users)
    {
        int? selectedIndexOfUser = null;

        Action<User> HandleSelectAction = (user) => { };

        ConsoleMenu userSelectMenu = new("User for discount card");

        users
            .ToList()
            .ForEach(user =>
            {
                userSelectMenu.Add(
                    CreateSelectableUser(user),
                    () => selectedIndexOfUser = user.UserId
                );
            });

        userSelectMenu.Show();
        return selectedIndexOfUser;
    }

    public int DisplayDiscountCardSelectMenu(
        IEnumerable<KeyValuePair<int, string>> discountCardTypes
    )
    {
        int selectedDiscountCardType = -1;
        ConsoleMenu discountCardSelectMenu = new("Discount card type");

        discountCardTypes
            .ToList()
            .ForEach(discountCardType =>
            {
                discountCardSelectMenu.Add(
                    discountCardType.Value,
                    () => selectedDiscountCardType = discountCardType.Key
                );
            });

        discountCardSelectMenu.Show();
        return selectedDiscountCardType;
    }

    private void DisplaySingleUserDiscount(User user)
    {
        string discountCardType = user.DiscountCard == null
            ? "None"
            : user.DiscountCard.GetType().Name;

        string displayString =
            $"{user.FirstName} {user.LastName} [{user.Username}]"
            + $" (Discount type: {discountCardType})";

        Console.WriteLine(displayString);
    }

    public void DisplayUserDiscountCards(IEnumerable<User> users)
    {
        Console.Clear();
        Console.WriteLine("[Users & discount cards]" + Environment.NewLine);

        users
            .ToList()
            .ForEach(user => DisplaySingleUserDiscount(user));

        Console.WriteLine();
    }
}
