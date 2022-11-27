namespace TaxCalculator.Domain.Models.Taxes
{
    public class TaxableCriteria
    {
        public decimal MinThreshold { get; private set; }

        public decimal MaxThreshold { get; private set; }

        public decimal Rate { get; private set; }

        public TaxableCriteria(
            decimal rate,
            decimal minThreshold,
            decimal maxThreshold
            )
        {
            Rate = rate;
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
        }
    }
}
