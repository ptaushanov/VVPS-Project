namespace VVPS
{
    public class ElderlyDiscountCard : DiscountCard
    {
        private double _discountValue;

        public ElderlyDiscountCard(string firstName, string lastName) : base(firstName, lastName)
        {
            DiscountValue = 0.34;
        }

        public override double DiscountValue {
            get => _discountValue;
            set => _discountValue = value;
        }
    }
}
