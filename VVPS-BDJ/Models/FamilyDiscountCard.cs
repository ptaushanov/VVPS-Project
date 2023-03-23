namespace VVPS_BDJ.Models
{
    public class FamilyDiscountCard : DiscountCard
    {
        public override double DiscountValue { get; set; }

        public FamilyDiscountCard() { }

        public FamilyDiscountCard(int? id)
            : base(id)
        {
            DiscountValue = 0.1;
        }

        public void ChangeDiscount(bool childUnder16Present)
        {
            DiscountValue = childUnder16Present ? 0.5 : 0.1;
        }
    }
}
