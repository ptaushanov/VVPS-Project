namespace VVPS_BDJ.Models
{
    public abstract class DiscountCard
    {
        public int? DiscountCardId { get; set; }

        public abstract double DiscountValue { get; set; }

        protected DiscountCard() { }

        protected DiscountCard(int? discountCardId)
        {
            DiscountCardId = discountCardId;
        }
    }
}
