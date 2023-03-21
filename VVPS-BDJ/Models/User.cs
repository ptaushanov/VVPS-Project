namespace VVPS_BDJ.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsAdmin { get; set; }
        public DiscountCard? DiscountCard { get; set; }

        public User() { }

        public User(
            int userId,
            string firstName,
            string lastName,
            string userName,
            string password,
            DateTime dateOfBirth,
            DiscountCard discountCard,
            bool isAdmin = false
        )
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
            Password = password;
            DateOfBirth = dateOfBirth;
            DiscountCard = discountCard;
            IsAdmin = isAdmin;
        }

        public User(
            int? userId,
            string firstName,
            string lastName,
            string userName,
            string password,
            DateTime dateOfBirth,
            bool isAdmin = false
        )
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Username = userName;
            Password = password;
            DateOfBirth = dateOfBirth;
            DiscountCard = null;
            IsAdmin = isAdmin;
        }

        public void CopyProperties(User user, bool skipEmptyValues = false)
        {
            if (skipEmptyValues)
            {
                if (user.FirstName != string.Empty) FirstName = user.FirstName;
                if (user.LastName != string.Empty) LastName = user.LastName;
                if (user.Username != string.Empty) Username = user.Username;
                if (user.Password != string.Empty) Password = user.Password;
                return;
            }

            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Password = user.Password;
        }
    }
}
