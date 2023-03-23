namespace VVPS_BDJ.Models
{
    public class ElderlyDiscountCard : DiscountCard
    {
        public override double DiscountValue { get; set; }

        public ElderlyDiscountCard() { }

        public ElderlyDiscountCard(int? id)
            : base(id)
        {
            DiscountValue = 0.34;
        }

    }
}
