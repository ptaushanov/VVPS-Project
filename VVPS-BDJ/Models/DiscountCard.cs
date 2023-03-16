namespace VVPS_BDJ.Models
{
    public abstract class DiscountCard
    {
        public int? DiscountCardId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public abstract double DiscountValue { get; set; }

        protected DiscountCard(){}

        public DiscountCard(int? discountCardId, string firstName, string lastName)
        {
            DiscountCardId = discountCardId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
