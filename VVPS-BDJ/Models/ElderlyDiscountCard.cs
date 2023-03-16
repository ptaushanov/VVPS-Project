namespace VVPS_BDJ.Models
{
    public class ElderlyDiscountCard : DiscountCard
    {
        private double _discountValue;

        public ElderlyDiscountCard() {}

        public ElderlyDiscountCard(int? id, string firstName, string lastName) 
            : base(id, firstName, lastName)
        {
            DiscountValue = 0.34;
        }

        public override double DiscountValue
        {
            get => _discountValue;
            set => _discountValue = value;
        }
    }
}
