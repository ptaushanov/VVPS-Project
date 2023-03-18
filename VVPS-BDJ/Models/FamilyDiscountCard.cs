namespace VVPS_BDJ.Models
{
    public class FamilyDiscountCard : DiscountCard
    {
        private double _discountValue;

        public FamilyDiscountCard() { }

        public FamilyDiscountCard(int? id)
            : base(id)
        {
            _discountValue = 0.1;
        }

        public override double DiscountValue
        {
            get => _discountValue;
            set => _discountValue = value;
        }

        public void ChangeDiscount(bool childUnder16Present)
        {
            DiscountValue = childUnder16Present ? 0.5 : 0.1;
        }
    }
}
