using System;

namespace VVPS
{
    public abstract class DiscountCard
    {
        private static Random _randomizer = new Random();
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public abstract double DiscountValue { get; set; }

        public DiscountCard(string firstName, string lastName)
        {
            int randomInt = _randomizer.Next(100000, 999999);
            Id = $"CARD{randomInt}BDJ";
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
