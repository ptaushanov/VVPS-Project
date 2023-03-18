namespace VVPS_BDJ.Models
{
    public abstract class DiscountCard
    {
        public int? DiscountCardId { get; private set; }

        public abstract double DiscountValue { get; set; }

        protected DiscountCard() { }

        public DiscountCard(int? discountCardId)
        {
            DiscountCardId = discountCardId;
        }
    }
}
