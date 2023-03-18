namespace VVPS_BDJ.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsAdmin { get; set; }
        public DiscountCard? DiscountCard { get; set; }

        public User() { }

        public User(
            int userId, string firstName, string lastName, string userName,
            DateTime dateOfBirth, DiscountCard discountCard, bool isAdmin = false
        )
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            DateOfBirth = dateOfBirth;
            DiscountCard = discountCard;
            IsAdmin = isAdmin;
        }

        public User(
            int userId, string firstName, string lastName, string userName,
            DateTime dateOfBirth, bool isAdmin = false
        )
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            DateOfBirth = dateOfBirth;
            DiscountCard = null;
            IsAdmin = isAdmin;
        }
    }
}
